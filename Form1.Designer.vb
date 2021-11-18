<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BotaoAtualiza = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.printButton = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.selecao = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.nomepessoa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.convenio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BotaoSair = New System.Windows.Forms.Button()
        Me.texto = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tconvenio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.label_qtd = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.controle_espaco = New System.Windows.Forms.NumericUpDown()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.botaoPageSetup = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.controle_linha = New System.Windows.Forms.NumericUpDown()
        Me.tmedico = New System.Windows.Forms.TextBox()
        Me.combo_medico = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.label_data = New System.Windows.Forms.Label()
        Me.BotaoLimparLista = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.botaoSelecionaAll = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.controle_espaco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.controle_linha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BotaoAtualiza
        '
        Me.BotaoAtualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotaoAtualiza.Location = New System.Drawing.Point(903, 572)
        Me.BotaoAtualiza.Name = "BotaoAtualiza"
        Me.BotaoAtualiza.Size = New System.Drawing.Size(65, 24)
        Me.BotaoAtualiza.TabIndex = 4
        Me.BotaoAtualiza.Text = "Atualiza"
        Me.BotaoAtualiza.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'printButton
        '
        Me.printButton.BackColor = System.Drawing.SystemColors.Control
        Me.printButton.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printButton.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.printButton.Image = CType(resources.GetObject("printButton.Image"), System.Drawing.Image)
        Me.printButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.printButton.Location = New System.Drawing.Point(812, 304)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(154, 56)
        Me.printButton.TabIndex = 5
        Me.printButton.Text = "Visualizar / Imprimir"
        Me.printButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.printButton.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(113, 183)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 21)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "DATA:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(107, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 30)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Laudo de Preventivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "status:"
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.Location = New System.Drawing.Point(69, 253)
        Me.label.MaximumSize = New System.Drawing.Size(0, 80)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(23, 17)
        Me.label.TabIndex = 10
        Me.label.Text = "   "
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selecao, Me.nomepessoa, Me.convenio, Me.Data, Me.medico})
        Me.DataGridView1.GridColor = System.Drawing.Color.Black
        Me.DataGridView1.Location = New System.Drawing.Point(10, 292)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(796, 304)
        Me.DataGridView1.TabIndex = 11
        '
        'selecao
        '
        Me.selecao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.selecao.HeaderText = "Selecione"
        Me.selecao.Name = "selecao"
        Me.selecao.Width = 69
        '
        'nomepessoa
        '
        Me.nomepessoa.FillWeight = 300.0!
        Me.nomepessoa.HeaderText = "Nome  Do  Paciente "
        Me.nomepessoa.Name = "nomepessoa"
        Me.nomepessoa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nomepessoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'convenio
        '
        Me.convenio.HeaderText = "Convenio"
        Me.convenio.Name = "convenio"
        Me.convenio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.convenio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Data
        '
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        '
        'medico
        '
        Me.medico.HeaderText = "médico"
        Me.medico.Name = "medico"
        '
        'BotaoSair
        '
        Me.BotaoSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotaoSair.Image = CType(resources.GetObject("BotaoSair.Image"), System.Drawing.Image)
        Me.BotaoSair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BotaoSair.Location = New System.Drawing.Point(815, 496)
        Me.BotaoSair.Name = "BotaoSair"
        Me.BotaoSair.Size = New System.Drawing.Size(150, 40)
        Me.BotaoSair.TabIndex = 12
        Me.BotaoSair.Text = "   SAIR"
        Me.BotaoSair.UseVisualStyleBackColor = True
        '
        'texto
        '
        Me.texto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.texto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.texto.BackColor = System.Drawing.SystemColors.Window
        Me.texto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texto.Location = New System.Drawing.Point(113, 107)
        Me.texto.Name = "texto"
        Me.texto.Size = New System.Drawing.Size(342, 22)
        Me.texto.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Linen
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(504, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 51)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Adicionar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Nome:"
        '
        'tconvenio
        '
        Me.tconvenio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tconvenio.Location = New System.Drawing.Point(113, 145)
        Me.tconvenio.Name = "tconvenio"
        Me.tconvenio.Size = New System.Drawing.Size(342, 22)
        Me.tconvenio.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Convênio:"
        '
        'Button2
        '
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(835, 559)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 48)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Atualiza Banco de Dados"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Quantidade:"
        '
        'label_qtd
        '
        Me.label_qtd.AutoSize = True
        Me.label_qtd.Location = New System.Drawing.Point(113, 227)
        Me.label_qtd.Name = "label_qtd"
        Me.label_qtd.Size = New System.Drawing.Size(10, 15)
        Me.label_qtd.TabIndex = 20
        Me.label_qtd.Text = " "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 67)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label7.Location = New System.Drawing.Point(113, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(419, 15)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "obs: Para mudar o nome na tabela, dê dois cliques na celula ou aperte F2"
        '
        'controle_espaco
        '
        Me.controle_espaco.Location = New System.Drawing.Point(9, 37)
        Me.controle_espaco.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.controle_espaco.Name = "controle_espaco"
        Me.controle_espaco.Size = New System.Drawing.Size(61, 21)
        Me.controle_espaco.TabIndex = 23
        Me.controle_espaco.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'botaoPageSetup
        '
        Me.botaoPageSetup.Location = New System.Drawing.Point(812, 238)
        Me.botaoPageSetup.Name = "botaoPageSetup"
        Me.botaoPageSetup.Size = New System.Drawing.Size(154, 49)
        Me.botaoPageSetup.TabIndex = 24
        Me.botaoPageSetup.Text = "Setup Impressão"
        Me.botaoPageSetup.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Localização Horizontal (150)"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.controle_linha)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.controle_espaco)
        Me.GroupBox1.Location = New System.Drawing.Point(697, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 122)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuração Impressão"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 15)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Controle vertical (1100)"
        '
        'controle_linha
        '
        Me.controle_linha.Location = New System.Drawing.Point(8, 84)
        Me.controle_linha.Maximum = New Decimal(New Integer() {1999, 0, 0, 0})
        Me.controle_linha.Name = "controle_linha"
        Me.controle_linha.Size = New System.Drawing.Size(61, 21)
        Me.controle_linha.TabIndex = 26
        Me.controle_linha.Value = New Decimal(New Integer() {1100, 0, 0, 0})
        '
        'tmedico
        '
        Me.tmedico.Location = New System.Drawing.Point(346, 184)
        Me.tmedico.Name = "tmedico"
        Me.tmedico.Size = New System.Drawing.Size(294, 21)
        Me.tmedico.TabIndex = 27
        '
        'combo_medico
        '
        Me.combo_medico.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_medico.FormattingEnabled = True
        Me.combo_medico.Items.AddRange(New Object() {"Dra.", "Dr."})
        Me.combo_medico.Location = New System.Drawing.Point(281, 184)
        Me.combo_medico.Name = "combo_medico"
        Me.combo_medico.Size = New System.Drawing.Size(59, 24)
        Me.combo_medico.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Médico:"
        '
        'label_data
        '
        Me.label_data.AutoSize = True
        Me.label_data.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_data.Location = New System.Drawing.Point(126, 69)
        Me.label_data.Name = "label_data"
        Me.label_data.Size = New System.Drawing.Size(0, 17)
        Me.label_data.TabIndex = 30
        '
        'BotaoLimparLista
        '
        Me.BotaoLimparLista.Image = CType(resources.GetObject("BotaoLimparLista.Image"), System.Drawing.Image)
        Me.BotaoLimparLista.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BotaoLimparLista.Location = New System.Drawing.Point(816, 374)
        Me.BotaoLimparLista.Name = "BotaoLimparLista"
        Me.BotaoLimparLista.Size = New System.Drawing.Size(149, 43)
        Me.BotaoLimparLista.TabIndex = 31
        Me.BotaoLimparLista.Text = "Apagar Lista    "
        Me.BotaoLimparLista.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(377, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 15)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "(Impressão da capa)"
        '
        'botaoSelecionaAll
        '
        Me.botaoSelecionaAll.Location = New System.Drawing.Point(818, 431)
        Me.botaoSelecionaAll.Name = "botaoSelecionaAll"
        Me.botaoSelecionaAll.Size = New System.Drawing.Size(146, 41)
        Me.botaoSelecionaAll.TabIndex = 33
        Me.botaoSelecionaAll.Text = "Seleciona todos"
        Me.botaoSelecionaAll.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 608)
        Me.Controls.Add(Me.botaoSelecionaAll)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BotaoLimparLista)
        Me.Controls.Add(Me.label_data)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.combo_medico)
        Me.Controls.Add(Me.tmedico)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.botaoPageSetup)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.label_qtd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tconvenio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.texto)
        Me.Controls.Add(Me.BotaoSair)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.BotaoAtualiza)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(20, 10)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão de Laudos de preventivo      Versão  2011                              " & _
            "              by  Gabriel Rocha  ® ™"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.controle_espaco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.controle_linha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BotaoAtualiza As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents printButton As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BotaoSair As System.Windows.Forms.Button
    Friend WithEvents texto As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tconvenio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents label_qtd As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents controle_espaco As System.Windows.Forms.NumericUpDown
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents botaoPageSetup As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents controle_linha As System.Windows.Forms.NumericUpDown
    Friend WithEvents tmedico As System.Windows.Forms.TextBox
    Friend WithEvents combo_medico As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents label_data As System.Windows.Forms.Label
    Friend WithEvents BotaoLimparLista As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents selecao As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents nomepessoa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents convenio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents medico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents botaoSelecionaAll As System.Windows.Forms.Button

End Class
