Imports System.Data

Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO   ' PARA ABRIR ARQUIVO TEXTO
'- #######################atualizado 15/08/2013 tudo funcionando ok##################
'-LISTA NOMES do arquivo de pacientes ,pega convenio E IMPRIME 
'-TEM Q INSTALAR O NETProvider-2.6.0.msi
'-a data tem q coloca format: CUSTOm e CustomFormat: dd.MM.yyyy
'-PODE USAR O DSN PARA CONECCAO DE BANCO DE DADOS
' IMPLANTAR PESQUISA DE DATA ULTIMO EXAME
'SELECT MAX(T_PACIENTESCONTAS.DATAEMISSAOGUIA)FROM T_PACIENTESCONTAS WHERE  T_PACIENTESCONTAS.PACIENTE = 1988

'##OBS  imprimir como oficio se o papel for muito grande
Public Class Form1
    Public primeiravez As Boolean
    Public linha_atual_datagrid, linhas_totais As Integer
    Public pagina_atual, qtd_linhas_atuais, ultimo_indice_checked, ponto_inserir_atual As Integer
    Public espaco, linha_da_impressao As Integer  ' espaco entre os nomes na impressao
    Public data_pesquisa As Date
    Public convenio_nome, nome_paciente As String
    Public linha_atual_grid, qtd_pacientes As Integer

    ' NAO DA ERRO QUANDO RODA,FALTA TESTAR SE ESTA LISTANDO OS COMANDOS
    'mostra dados corretamente falta colocar numa tabela

    'CHAMA ESSA FUNCAO QUANDO  O FORMULARIO CARREGA
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).RenderMode = ToolStripRenderMode.Professional
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).GripStyle = ToolStripGripStyle.Visible
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).Height = 50
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).Width = 120


        texto.Visible = False
        tconvenio.Visible = False
        Dim hoje As Date = Today()
        label_data.Text = "Data de hoje: " & hoje
        'pra colocar o item Dra aparecendo primeiro no comboBox
        combo_medico.Text = "Dra."
        tmedico.Text = "Maria da Conceição Pinho Rocha"
        '### remover talvez
        'Dim coluna As New DataGridViewCheckBoxColumn()

        '        coluna.HeaderText = "Selecione"
        '       coluna.Name = "selecao"
        '      DataGridView1.Columns.Insert(0, coluna)

        '########################adiciona strings na colecao
        'texto.AutoCompleteCustomSource.Add("maria")
        'texto.AutoCompleteCustomSource.Add("maria claudia")
        'texto.AutoCompleteCustomSource.Add("maria claudia santana")
        Me.linha_atual_grid = 0  ' a linha atual do datagrid que comecara a inserir valores
        Me.ponto_inserir_atual = 0 ' PONTO NO DATAGRID QUE INSERE DADOS, O LINHA_ATUAL_DATAGRID E USADO PELA IMPRESSAO
        label_qtd.Text = " 0"
        BotaoAtualiza.Enabled = False ' desabilita borao atualiza datagrid
        BotaoAtualiza.Hide()
        Button2.Enabled = False ' desabilita o borao atualiza banco de dados
        Button2.Hide()

        'DataGridView1.Columns(1).Width = 330 ' NOME
        ' DataGridView1.Columns(2).Width = 140 'CONVENIO
        ' DataGridView1.Columns(3).Width = 100 ' DATA
    End Sub

    '###retorna o convenio a partir do numero

    'pesquisa os nomes no banco de dados do prodoctor 9  e preenche o textfield
    Public Sub PesquisaNome()
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        Dim myData As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim linhas As Integer
        Dim lista_de_nomes As New AutoCompleteStringCollection
        linhas = 0

        Try
            'Me.data_pesquisa = DateTimePicker1.Value.Date
            'caminho do banco de dados C:\
            '##PODE USAR ASSIM    cn.ConnectionString = "Provider=ZStyle IBOLE Provider;Data Source=.\PRODOCTORSQL.FDB;UID=sysdba;password=masterkey"
            '##OU COM DSN TAMBEM
            cn.ConnectionString = "DSN=prodoctorcorp"
            'sql = "SELECT  T_PacientesContas.Paciente,T_PacientesContas.Conta,T_PacientesContas.CONS_HD_CID1_CODIGO from T_PacientesContas where T_PacientesContas.CONS_HD_CID1_CODIGO = '' and T_PacientesContas.convenio = 74"
            sql = "SELECT T_PACIENTES.nome  from T_PACIENTES "
            'usuario=1 dra conceicao
            'sql = "SELECT   T_AGENDACONSULTAS.USUARIO, T_AGENDACONSULTAS.NOMEPACIENTE,T_AGENDACONSULTAS.DATA, T_AGENDACONSULTAS.NUMEROPRONTUARIO,T_AGENDACONSULTAS.CONVENIO,T_PACIENTES.NOME FROM T_AGENDACONSULTAS INNER  JOIN  T_PACIENTES     ON T_AGENDACONSULTAS.USUARIO = 1 AND  T_AGENDACONSULTAS.DATA = '" & data_pesquisa & "' AND  T_AGENDACONSULTAS.NUMEROPRONTUARIO = T_PACIENTES.CODIGO"
            cn.Open()

            rs = cn.Execute(sql)
            linhas = 0


            'linhas = rs.RecordCount ' conTA quantidade de REGISTROS do resultset
            texto.AutoCompleteCustomSource.Clear()
            Do While Not rs.EOF
                ' 'nao tem listbox, adicionar se quiser
                'listbox.Items.Add("Valor1: " & rs(0).Value.ToString & "  Valor2: " & rs(1).Value.ToString & " Valor3:" & rs(2).Value.ToString)

                'texto.AutoCompleteCustomSource.Add(rs(0).Value.ToString)
                lista_de_nomes.Add(rs(0).Value.ToString)
                'MsgBox("nome " & rs(1).ToString)
                rs.MoveNext()
                linhas = linhas + 1
            Loop
            'AQUI JOGA A LISTA DE NOMES NO CONTROLE,QUE MELHORA VELOCIDADE DO PROGRAMA 
            texto.AutoCompleteCustomSource = lista_de_nomes

            rs.Close()
            cn.Close()

        Catch ex As Exception

            MsgBox("ERRO PESQUISANDO NOME: " & ex.ToString, MsgBoxStyle.Critical, "Erro Pesquisa do Nome dos Pacientes")
        End Try


    End Sub


    Public Sub PesquisaConvenio()
        Dim cn As New ADODB.Connection
        Dim rs2 As New ADODB.Recordset
        Dim sql, sql_conv As String ' sql_conv é string do convenio atual para busca

        Dim myData As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim linhas, convenio_padrao, prontuario As Integer
        linhas = 0

        Try
            'Me.data_pesquisa = DateTimePicker1.Value.Date
            'caminho do banco de dados .\PRODOCTOR.FDB
            'PODE USAR: cn.ConnectionString = "Provider=ZStyle IBOLE Provider;Data Source=.\PRODOCTORSQL.FDB;UID=sysdba;password=masterkey"
            '##OU TAMBEM:
            cn.ConnectionString = "DSN=prodoctorcorp"
            'sql = "SELECT  T_PacientesContas.Paciente,T_PacientesContas.Conta,T_PacientesContas.CONS_HD_CID1_CODIGO from T_PacientesContas where T_PacientesContas.CONS_HD_CID1_CODIGO = '' and T_PacientesContas.convenio = 74"

            nome_paciente = texto.Text.ToString
            sql = "SELECT T_PACIENTES.CONVENIOPADRAO,T_PACIENTES.CODIGO from T_PACIENTES WHERE T_PACIENTES.NOME LIKE '" & nome_paciente & "%'"
            'usuario=1 dra conceicao
            'sql = "SELECT   T_AGENDACONSULTAS.USUARIO, T_AGENDACONSULTAS.NOMEPACIENTE,T_AGENDACONSULTAS.DATA, T_AGENDACONSULTAS.NUMEROPRONTUARIO,T_AGENDACONSULTAS.CONVENIO,T_PACIENTES.NOME FROM T_AGENDACONSULTAS INNER  JOIN  T_PACIENTES     ON T_AGENDACONSULTAS.USUARIO = 1 AND  T_AGENDACONSULTAS.DATA = '" & data_pesquisa & "' AND  T_AGENDACONSULTAS.NUMEROPRONTUARIO = T_PACIENTES.CODIGO"
            cn.Open()
            rs2 = cn.Execute(sql)


            'procura conveniopadrao,e pega a variavel se é convenio_1,convenio_2..etc para busca no T_Convenios
            Do While Not rs2.EOF
                convenio_padrao = rs2(0).Value ' valor do conveniopadrao 0,1,2
                prontuario = rs2(1).Value ' prontuario do paciente
                'texto.AutoCompleteCustomSource.Add(rs(1).Value.ToString)
                'MsgBox("nome " & rs(1).ToString)
                rs2.MoveNext()

            Loop


            sql_conv = " - "
            '#### testa qual convenio é o padrao dos 3
            If convenio_padrao = 0 Then
                sql_conv = "SELECT T_CONVENIOS.nome FROM T_CONVENIOS INNER JOIN T_PACIENTES ON T_PACIENTES.CONVENIO_1 = T_CONVENIOS.CODIGO AND  T_PACIENTES.codigo = " & prontuario
            ElseIf convenio_padrao = 1 Then
                sql_conv = "SELECT T_CONVENIOS.nome FROM T_CONVENIOS INNER JOIN T_PACIENTES ON T_PACIENTES.CONVENIO_2 = T_CONVENIOS.CODIGO AND  T_PACIENTES.codigo = " & prontuario
            ElseIf convenio_padrao = 2 Then
                sql_conv = "SELECT T_CONVENIOS.nome FROM T_CONVENIOS INNER JOIN T_PACIENTES ON T_PACIENTES.CONVENIO_3 = T_CONVENIOS.CODIGO AND  T_PACIENTES.codigo = " & prontuario

            End If
            '## pesquisa de novo com nova string de pesquisa o convenio
            rs2 = cn.Execute(sql_conv)
            convenio_nome = ""
            Do While Not rs2.EOF
                convenio_nome = rs2(0).Value.ToString
                rs2.MoveNext()

            Loop
            'diminuindo nome dos convenios
            If convenio_nome.ToUpper.StartsWith("GOLDEN") Then
                convenio_nome = "Golden Cross"
            ElseIf convenio_nome.ToUpper.StartsWith("PETROBR") Then
                convenio_nome = "Petrobrás"
            ElseIf convenio_nome.ToUpper.StartsWith("AMIL") Then
                convenio_nome = "Amil"
            ElseIf convenio_nome.ToUpper.StartsWith("BRADESC") Then
                convenio_nome = "Bradesco"
            ElseIf convenio_nome.ToUpper.StartsWith("PARTIC") Then
                convenio_nome = "Particular"
            End If


            tconvenio.Text = convenio_nome


            rs2.Close()
            cn.Close()

        Catch ex As Exception
            MsgBox("Sem convênio ou Paciente não cadastrado")
        End Try

    End Sub

    'essa procedure recebe uma string de coneccao sql para o banco firebird
    'E PREENCHE UM DATAGRIDVIEW COM OS CAMPOS
    Public Sub AtualizaDatagrid(ByVal stringcon As System.String) ' atualiza os dados no datagrid
        'Coneccao do FIREBIRD DO PRODOCTOR 9 abaixo:
        'conn.ConnectionString = "Provider=ZStyle IBOLE Provider;Data Source=c:\PRODOCTORSQL.FDB;UID=sysdba;password=masterkey"
        '"select nome,SUM(valorbruto) AS total from t_cartoes GROUP BY t_cartoes.nome"
        '"select top 10 * from t_cartoes where t_cartoes.data BETWEEN '1/07/2010'  AND  '01/09/2010' order by t_cartoes.nome"
        ' numero para teste t_cartoes.Código585
        'Dim da As New OleDbDataAdapter("select  top 20 * from t_cartoes where t_cartoes.data BETWEEN datevalue('" & pegadata.Value.Date & "')  AND  datevalue('" & pegadata2.Value.Date & "') order by t_cartoes.nome", conn)
        'Dim da As New OleDbDataAdapter("select  * from t_cartoes where t_cartoes.Código=585 ", conn)
        Dim conn As New OleDbConnection()
        label.ForeColor = Color.Blue
        label.Text = "TENTANDO ConectaR..."
        '###PODE USAR TB: conn.ConnectionString = "Provider=ZStyle IBOLE Provider;Data Source=C:\PRODOCTORSQL.FDB;UID=sysdba;password=masterkey"
        conn.ConnectionString = "DSN=prodoctorcorp"
        Dim cmd As OleDbCommand = conn.CreateCommand
        Dim da As New OleDbDataAdapter(stringcon, conn)
        Dim dt As New DataTable
        ' Dim dr As OleDbDataReader
        'adiciona uma coluna DE checKbOX antes das outras

        Try

            da.Fill(dt)
            DataGridView1.DataSource = dt

            'DataGridView1.Columns.Item(1).HeaderText = "Nome do paciente"
            label.ForeColor = Color.Green
            label.Text = "Conectado..."
            'codigo para ler os valores da pesquisa
            'conn.Open()
            ' cmd.ExecuteNonQuery() ' para inserir dados e executereader para ler
            ' dr = cmd.ExecuteReader() ' ExecuteNonQuery()

            
            'While dr.Read()
            '    DataGridView1.Rows.Add(1)
            'box.AppendText("Campo 1:" & dr(0) & "  campo 2:" & dr(1) & " Campo 3" & dr(2) & vbLf)
            ' loading data into TextBoxes by column index

            'End While



            '#################codigo para lanca convenios
            'Dim coluna As New DataGridViewTextBoxColumn()
            'coluna.HeaderText = "NOme Convenio"
            'coluna.Name = "NOmeconvenio"
            'DataGridView1.Columns.Insert(5, coluna)
            ' linhas = DataGridView1.RowCount - 2
            ' For i = 0 To linhas ' LINHAS= LINHAS TOTAIS DO DATAGRID PREENCHIDO
            '            If IsDBNull(DataGridView1.Rows(i).Cells(2).Value) Then
            'nome_do_convenio = " "

            'Else
            'numero_do_convenio = DataGridView1.Rows(i).Cells(2).Value
            'nome_do_convenio = RetornaConvenio(numero_do_convenio)
            'End If


            'DataGridView1.Rows(i).Cells(5).Value = nome_do_convenio


            'Next i

            '### remover depois 
            ' DataGridView1.Columns.RemoveAt(2)  


            da.Dispose()
            conn.Close()
            label.ForeColor = Color.Red
            label.Text = "NÃO Conectado..."

            'MsgBox(" sucesso !", MsgBoxStyle.Information, "Incluindo registros")
        Catch erro As Exception
            MsgBox("Erro ATUALIZANDO.:" & vbCrLf & erro.ToString, MsgBoxStyle.Critical, "Erro")
            label.ForeColor = Color.Red
            label.Text = "NÃO Conectado..."
        End Try

    End Sub

    Private Sub BotaoAtualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotaoAtualiza.Click
        Dim s1, data_ok As String

        Me.data_pesquisa = DateTimePicker1.Value.Date
        data_ok = Me.data_pesquisa.Day & "." & Me.data_pesquisa.Month & "." & Me.data_pesquisa.Year
        'MsgBox("data: " & data_ok, MsgBoxStyle.Critical, "")

        s1 = "SELECT T_AGENDACONSULTAS.NOMEPACIENTE,T_AGENDACONSULTAS.CONVENIO,T_AGENDACONSULTAS.DATA,T_AGENDACONSULTAS.NUMEROPRONTUARIO FROM T_AGENDACONSULTAS WHERE  T_AGENDACONSULTAS.USUARIO = 1 AND T_AGENDACONSULTAS.DATA = '" & data_ok & "' order by  T_AGENDACONSULTAS.NOMEPACIENTE"  'AND T_AGENDACONSULTAS.NUMEROPRONTUARIO = T_PACIENTES.CODIGO"
        Me.AtualizaDatagrid(s1)
    End Sub

    Private Sub printButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printButton.Click
        ' tem q testar qual tipo de relatorio usuario quer..
        Dim altura, largura As Integer

        altura = My.Computer.Screen.Bounds.Height 'pega altura da tela
        largura = My.Computer.Screen.Bounds.Width ' pega largura da tela
        Try
            If DataGridView1.RowCount > 1 Then

                '##################codigo pra melhorar o visual do preview
                PrintPreviewDialog1.Refresh()
                '#########################################
                MsgBox("--------->  Para immprimir corretamente,ir em ""Setup Impressão"" e colocar papel tipo ""OFICIO"" para imprimir.  <--------", MsgBoxStyle.Exclamation, "")

                PrintPreviewDialog1.SetDesktopBounds(3, 3, largura, altura)
                PrintPreviewDialog1.PrintPreviewControl.Zoom = 0.6 ' 1= auto 0.8 80%
                PrintPreviewDialog1.PrintPreviewControl.StartPage = 0 ' pagina q mosra o preview
                PrintPreviewDialog1.ShowDialog()

            Else
                MsgBox("Lista vazia", MsgBoxStyle.Critical, "Erro!")
            End If ' if do datagridrow.cout

        Catch ex As Exception
            MsgBox("NAda para visualizar", MsgBoxStyle.Critical, "ERRO")
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' se o papel for muito grande mudar para tipo: oficio ao invez de A4
        ' Set current thread culture to en-US.
        'Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        'criado uima variavel primeiravez para que use toda vez q entrar na impressao saber qual
        Dim font1 As New Font("Arial", 10, FontStyle.Regular)
        Dim font2 As New Font("Arial", 10, FontStyle.Bold) ' Fonte do valor liquid negrito
        Dim font_cabecalho As New Font("Arial", 10, FontStyle.Bold) ' Fonte do valor liquid negrito
        Dim caneta As New Pen(Color.Black, 2)    ' caneta para pintar uma linha
        Dim nome, data, nome_medico As String
        Dim linhas, linha_atual, i As Integer

        Dim drawFormat As New StringFormat  ' imprimir a direita
        Dim linhas_porpagina, j As Integer


        '  MsgBox("he=" & PrintDocument1.DefaultPageSettings.PrintableArea.Height & "  wid=" & PrintDocument1.DefaultPageSettings.PrintableArea.Width, MsgBoxStyle.ApplicationModal, "")



        '#### codigo da imagem do logotipo
        'Dim newImage As Image = Image.FromFile("logo.jpg")
        'Dim ponto As New PointF(50.0F, 10.0F)
        'e.Graphics.DrawImage(newImage, ponto) ' desenha o logotipo
        'fim codigo da imagem do logotipo
        'nome padrao
        If tmedico.Text.Length = 0 Then  ' nao tem medico digitado no campo..
            nome_medico = ""
        Else
            nome_medico = combo_medico.Text & " " & tmedico.Text.ToString
        End If

        drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
        linhas_porpagina = 1 ' quantidade de linhas por pagina
        ' converte o valor para umax.ToString("#.###")
        qtd_linhas_atuais = 0 'sempre q entra ness funco zera as linhas atuais

        linha_atual = 160  ' comeca escrever na linha 1600
        Me.espaco = controle_espaco.Value ' ESPACO ENTRE  1 NOMES
        linhas = DataGridView1.RowCount - 2 ' n de linhas do grid tem q diminuir 1 por causa do * 
        'colunas = DataGridView1.ColumnCount - 1

        '##########testa o ultimo indice do j QUE TEM IDEM MARCADO  PRA IMPRIMIR
        Dim check As Boolean

        For j = 0 To linhas
            check = Convert.ToBoolean(DataGridView1.Rows(j).Cells(0).Value)
            If check Then
                ultimo_indice_checked = j
            End If
        Next j ' quando sair daqui armazeda onde esta ultimo indice do datagrid q ta checked
        'se nao tiver nada marcado,sai da funcao imprimir


        Me.linha_da_impressao = Me.controle_linha.Value    ' linha a partir da qual ocorrera a impressao
        If primeiravez = False Then ' Then
            Me.linha_atual_datagrid = 0 ' A linha atual do datagrid q sera usada na impresao de varias paginas
            linhas_totais = 0 'se 1 vez q imprime zera  linhas totais do documento
            pagina_atual = 1   ' ATUALIZA PAGINA

        End If
        'MsgBox("linash totais:" & linhas, MsgBoxStyle.Critical, "")

        For i = Me.linha_atual_datagrid To linhas ' LINHAS= LINHAS TOTAIS DO DATAGRID PREENCHIDO

            '##############testa se o checkbox esta selecionado para imprimir
            'SE TIVER MARCADO,IMPRIME

            'MessageBox.Show(DataGridView1.Rows(i).Cells(0).Value.ToString())
            If Convert.ToBoolean(DataGridView1.Rows(i).Cells(0).Value) Then


                '################## pegando dados doo datagridview e jogando em variaveis
                nome = DataGridView1.Rows(i).Cells(1).Value.ToString  ' NOME DO PAC
                ' If DataGridView1.Rows(i).Cells(2).Value IsNot DBNull.Value Then
                ' convenio_num = DataGridView1.Rows(i).Cells(2).Value ' convenio
                'Me.convenio_nome = RetornaConvenio(convenio_num)
                Me.convenio_nome = DataGridView1.Rows(i).Cells(2).Value.ToString
                'End If
                data = DataGridView1.Rows(i).Cells(3).Value ' se coloca .value.tostring imprime a hor tambem DATA CONSULTA
                'adiciona o campo medico no datagrid
                nome_medico = DataGridView1.Rows(i).Cells(4).Value.ToString
                e.Graphics.DrawString(nome, font_cabecalho, Brushes.Black, Me.espaco, Me.linha_da_impressao - 20) ' espaco sao as colunas
                '##############MEDICO############:

                e.Graphics.DrawString(nome_medico, font_cabecalho, Brushes.Black, Me.espaco, Me.linha_da_impressao + 20) ' Solicitante,geralmente Dra maria da conceicao

                e.Graphics.DrawString(convenio_nome, font_cabecalho, Brushes.Black, Me.espaco, Me.linha_da_impressao + 65) ' espaco sao as colunas
                e.Graphics.DrawString(data, font_cabecalho, Brushes.Black, Me.espaco, Me.linha_da_impressao + 100) ' espaco sao as colunas
                'e.Graphics.DrawString("PAGINA " & pagina_atual, font_cabecalho, Brushes.Black, 740, 1100)

                '#####################################imprime os dados
                linha_atual = linha_atual + 15             ' incrementa linha de impressao atual 
                qtd_linhas_atuais = qtd_linhas_atuais + 1 ' incrementa Quantidde De linhas por Pagina aqual
                linhas_totais = linhas_totais + 1
                If qtd_linhas_atuais >= linhas_porpagina Then ' se tiver linhas no datagrid pra imprimir ainda..

                    If i = ultimo_indice_checked Then
                        e.HasMorePages = False
                        primeiravez = False    ' volta a imprimir como 1 vez quando alguem apertar imprimir
                        Me.pagina_atual = 1 '
                        Me.linha_atual_datagrid = 1
                        Exit Sub ' sai da funcao
                    End If

                    e.HasMorePages = True 'volta a pagina documentprintpage
                    Me.pagina_atual = pagina_atual + 1
                    'se tiver mais paginas incrementa a proxima linha do datagrid para quando voltar continuar de onde parou
                    Me.linha_atual_datagrid = i + 1 ' incrementa a linha atual do datagrid
                    Me.primeiravez = True
                    Exit For ' EXIT FOR=sai da proximo comando de FOR
                    'CONTINUE FOR = continua para proximo for sem executar comandoa abaixos   
                    '    Exit For
                End If
            Else
                If i = linhas Then
                    primeiravez = False    ' volta a imprimir como 1 vez quando alguem apertar imprimir
                    Me.pagina_atual = 1 '
                    Me.linha_atual_datagrid = 1
                    e.HasMorePages = False
                    Exit For
                Else

                    ' continua o for na proximo valor de i
                    Continue For '
                End If ' i=linhas

            End If


        Next i ' for DA QUANTIDADE DE LINHAS DO DATAGRID



    End Sub

    Private Sub BotaoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotaoSair.Click
        Application.Exit()
    End Sub

    '######## INSERE DADOS NO DATAGRIDVIEW
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nome_medico As String

        'recupera o estado atual do datagrid se tiver pedido a impressao e visualizacao do doc
        If texto.Text.Length > 1 Then
            If DataGridView1.RowCount <> 0 Then 'se for 1 vez q inclui nao adiciona linha porq ja tem uma
                DataGridView1.Rows.Add() ' adicionar uma linha
            End If
            DataGridView1.Rows(Me.ponto_inserir_atual).Cells(0).Value = True
            DataGridView1.Rows(Me.ponto_inserir_atual).Cells(1).Value = texto.Text
            DataGridView1.Rows(Me.ponto_inserir_atual).Cells(2).Value = tconvenio.Text.ToString
            DataGridView1.Rows(Me.ponto_inserir_atual).Cells(3).Value = DateTimePicker1.Value.Date.Day & "/" & DateTimePicker1.Value.Date.Month & "/" & DateTimePicker1.Value.Date.Year
            '##> MOSTRA A ULTIMA CELULA INSERIDA,bom pra ir vendo o que esta sendo inserido
            DataGridView1.FirstDisplayedScrollingRowIndex = Me.ponto_inserir_atual

            If tmedico.Text.Length = 0 Then
                nome_medico = ""
            Else
                nome_medico = combo_medico.Text & " " & tmedico.Text.ToString
            End If
            DataGridView1.Rows(Me.ponto_inserir_atual).Cells(4).Value = nome_medico
            '#####
            Me.ponto_inserir_atual = Me.ponto_inserir_atual + 1
            texto.Text = ""
            tconvenio.Text = ""
            Me.qtd_pacientes = Me.qtd_pacientes + 1
            label_qtd.Text = Me.qtd_pacientes.ToString
            label.Text = "INSERIDO PACIENTE"

            'DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount
            'DataGridView1.CurrentCell = DataGridView1.CurrentRow.Cells(1)
            texto.Focus()

        ElseIf texto.Text.Length = 0 Then
            MsgBox("Insira um nome de paciente", MsgBoxStyle.Critical, "Erro no Cadastro")
            'coloca foco no texto pra pessoa inserir
            texto.Focus()
        End If
        
    End Sub


    'QUANDO PERDE O FOCO NO TEMPO TEXTFIELD CHAMA ESSA FUNCAO PRA PROCURAR O CONVENIO
    Private Sub texto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles texto.Leave
        If texto.Text.Length > 3 Then
            Me.PesquisaConvenio()
        End If

        'System.Console.
    End Sub

    'GRAVA ARQUIVO DO SERVIDOR PARA PASTA ATUAL onde o programa roda
    'nao precisa usar isso se usar O DSN pra coneccao
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' mostra caminho do executavedl do programa
        ' System.Reflection.Assembly.GetExecutingAssembly().Location)

        Try  ' LOCAL DO BANCO DE DADOS FIREBIRD
            FileCopy("\\Servidor\C\Prodoctor9\Dados\PRODOCTORSQL.FDB", Application.StartupPath & "\PRODOCTORSQL.FDB")
            label.ForeColor = Color.Blue
            label.Text = " Arquivo copiado!!Reinicie o aplicativo"
            'My.Computer.FileSystem.FileExists 
        Catch EX As Exception
            label.ForeColor = Color.Red
            label.Text = "erro: Arquivo não copiado!!" & vbCrLf & EX.Message
        End Try


        'mostra caminho da pasta do programa de inicio
        'Application.StartupPath

    End Sub

    Private Sub Button2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseDown
        label.ForeColor = Color.Blue
        label.Text = " Copiando arquivo do Servidor..aguarde.."
    End Sub

 
    'quando formulario é mostrado
    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'CARREGA A LISTA DE NOMES
        Try
            ' ### PARA SE USAR ARQUIVO If My.Computer.FileSystem.FileExists("PRODOCTORSQL.FDB") Then
            
            label.ForeColor = Color.Blue
            label.Text = "AGUARDE..ATUALIZANDO LISTA DE NOMES..."
            'LIMPA A TELA DO MSGBOX
            Me.Refresh()
            Me.PesquisaNome()

            'da foco no campo do nome pr ser digitado
            texto.Focus()
            label.ForeColor = Color.Green
            label.Text = "███---- ATUALIZACAO COMPLETADA ----███"
            texto.Visible = True
            tconvenio.Visible = True
            texto.Focus()
         

        Catch ex As Exception
            label.ForeColor = Color.Red
            label.Text = "ERRO: ATUALIZACAO NÃO COMPLETADA."
        End Try
        
    End Sub

    Private Sub texto_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles texto.Enter
        label.Text = ""
    End Sub

    
    Private Sub texto_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles texto.MouseDown
        If texto.Text.Length > 3 Then
            Me.PesquisaConvenio()
        End If
    End Sub

   
    Private Sub botaoPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botaoPageSetup.Click
        'coloca o DOcumento qud pagesetup vai usar 1 e chama o dialog
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub BotaoLimparLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotaoLimparLista.Click
        DataGridView1.Rows.Clear()
        Me.ponto_inserir_atual = 0
        Me.qtd_pacientes = 0
        label_qtd.Text = "0"
    End Sub

    Private Sub texto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles texto.KeyDown

        'Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        If e.KeyCode = Keys.Enter Then  ' digitou ENTER
            tconvenio.Focus()           ' da focus para convenio
        End If

    End Sub

    Private Sub DateTimePicker1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'da foco no botao de ADICIONAR
            tmedico.Focus()

        End If
    End Sub

    Private Sub tconvenio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tconvenio.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker1.Focus()
        End If
    End Sub

    Private Sub tmedico_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tmedico.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()

        End If
    End Sub

    Private Sub botaoSelecionaAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botaoSelecionaAll.Click
        Dim linhas As Integer
        linhas = DataGridView1.RowCount - 2 ' n de linhas do grid tem q diminuir 1 por causa do * 
        'colunas = DataGridView1.ColumnCount - 1

        '##########testa o ultimo indice do j QUE TEM IDEM MARCADO  PRA IMPRIMIR
        Dim check As Boolean


        For j = 0 To linhas
            check = Convert.ToBoolean(DataGridView1.Rows(j).Cells(0).Value)
            If check Then
                DataGridView1.Rows(j).Cells(0).Value = False
            Else
                DataGridView1.Rows(j).Cells(0).Value = True

            End If
        Next j ' quando sair daqui 
    End Sub
End Class
