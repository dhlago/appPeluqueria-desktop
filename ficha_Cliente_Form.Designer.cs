using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class ficha_Cliente_Form
    {
        private System.ComponentModel.IContainer components = null;

        // Banner superior
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;

        // Tab Control principal
        private TabControl tabControlPrincipal;
        private TabPage tabFichaPre;
        private TabPage tabManualAparato;
        private TabPage tabMicroTricoSeg;

        // Botones guardar/cancelar
        private Button btnGuardar;
        private Button btnCancelar;

        // --- TAB 1: FICHA Y PRE-DIAGNOSTICO ---
        private GroupBox gbDatosCliente;
        private Label lblFechaVisita;
        private TextBox txtFechaVisita;

        private GroupBox gbPreDiagnostico;
        private Label lblFrecuenciaLavado;
        private TextBox txtFrecuenciaLavado;
        private Label lblProductos;
        private TextBox txtProductos;

        private GroupBox gbEstadoCuero;
        private CheckBox chkCueroDescamacion;
        private CheckBox chkCueroGrasa;
        private CheckBox chkCueroCaida;
        private CheckBox chkCueroPicor;
        private CheckBox chkCueroNormal;
        private CheckBox chkCueroSeco;
        private CheckBox chkCueroGraso;

        private GroupBox gbEstadoCabello;
        private Label lblForma;
        private CheckBox chkCabelloLiso;
        private CheckBox chkCabelloOndulado;
        private CheckBox chkCabelloRizado;
        private Label lblAlteraciones;
        private TextBox txtAlteraciones;
        private Label lblColorMatiz;
        private TextBox txtColorMatiz;
        private Label lblCanas;
        private TextBox txtCanas;
        private Label lblGrosor;
        private TextBox txtGrosor;
        private Label lblLongitud;
        private TextBox txtLongitud;

        private GroupBox gbObservaciones;
        private TextBox txtObservaciones;

        // --- TAB 2: MANUAL Y APARATOLOGIA ---
        private GroupBox gbManualCuero;
        private Label lblPalpacion;
        private CheckBox chkPalpacionNormal;
        private CheckBox chkPalpacionHumedo;
        private CheckBox chkPalpacionUntuoso;

        private Label lblPresion;
        private CheckBox chkPresionNormal;
        private CheckBox chkPresionDeficiente;

        private Label lblMovilizacion;
        private CheckBox chkMovilizacionAdherencia;
        private CheckBox chkMovilizacionNo;

        private Label lblJaquet;
        private CheckBox chkJaquetPos;
        private CheckBox chkJaquetNeg;

        private Label lblSaboraud;
        private CheckBox chkSaboraudPos;
        private CheckBox chkSaboraudNeg;

        private Label lblPapel;
        private CheckBox chkPapelPos;
        private CheckBox chkPapelNeg;

        private GroupBox gbManualTallo;
        private Label lblTextura;
        private CheckBox chkTexturaFinas;
        private CheckBox chkTexturaGruesas;

        private Label lblPuntas;
        private CheckBox chkPuntasAbiertas;
        private CheckBox chkPuntasCerradas;

        private Label lblPull;
        private CheckBox chkPullPos;
        private CheckBox chkPullNeg;

        private Label lblDeslizar;
        private CheckBox chkDeslizarAlta;
        private CheckBox chkDeslizarMedia;
        private CheckBox chkDeslizarNinguna;

        private GroupBox gbAparatologia;
        private Label lblCorneometro;
        private CheckBox chkCorneoMuyDes;
        private CheckBox chkCorneoDes;
        private CheckBox chkCorneoNormal;
        private CheckBox chkCorneoMuyHid;

        private Label lblSebometro;
        private CheckBox chkSeboSeco;
        private CheckBox chkSeboNormal;
        private CheckBox chkSeboGraso;
        private CheckBox chkSeboSeborrea;

        private Label lblPh;
        private CheckBox chkPhNormal;
        private CheckBox chkPhAlto;
        private CheckBox chkPhBajo;

        private Label lblWood;
        private CheckBox chkWoodAmarillo;
        private CheckBox chkWoodVioClaro;
        private CheckBox chkWoodVioOscuro;
        private CheckBox chkWoodAzul;
        private CheckBox chkWoodBlanco;
        private CheckBox chkWoodOscuro;
        private CheckBox chkWoodDebil;

        private Label lblMicrocamara;
        private CheckBox chkMicroSueltas;
        private CheckBox chkMicroPegadas;
        private CheckBox chkMicroEritema;
        private CheckBox chkMicroGrasa;
        private CheckBox chkMicroMini;
        private CheckBox chkMicroObstruccion;
        private CheckBox chkMicroDebil;

        private Label lblObsAparatologia;
        private TextBox txtObsAparatologia;

        // --- TAB 3: MICROVISOR, TRICOGRAMA Y SEGUIMIENTO ---
        private GroupBox gbMicrovisor;
        private Label lblAnomalias;
        private CheckBox chkAnomTricorrexis;
        private CheckBox chkAnomMonilethrix;
        private CheckBox chkAnomPiliTorti;
        private CheckBox chkAnomPiliBifur;
        private CheckBox chkAnomTricInvag;
        private CheckBox chkAnomTricotio;

        private Label lblDano;
        private CheckBox chkDanoCuticula;
        private CheckBox chkDanoPuntas;
        private CheckBox chkDanoTricoNodosa;
        private CheckBox chkDanoTricoclasia;
        private CheckBox chkDanoTriconodosis;
        private CheckBox chkDanoTricolomania;
        private CheckBox chkDanoBayoneta;
        private CheckBox chkDanoEnfundado;

        private Label lblObsMicrovisor;
        private TextBox txtObsMicrovisor;

        private GroupBox gbTricograma;
        private Label lblTricoFrontal;
        private TextBox txtTricoFrontAnagena;
        private TextBox txtTricoFrontCatagena;
        private TextBox txtTricoFrontTelogena;

        private Label lblTricoTempIzq;
        private TextBox txtTricoTempIzqAnagena;
        private TextBox txtTricoTempIzqCatagena;
        private TextBox txtTricoTempIzqTelogena;

        private Label lblTricoTempDcho;
        private TextBox txtTricoTempDchoAnagena;
        private TextBox txtTricoTempDchoCatagena;
        private TextBox txtTricoTempDchoTelogena;

        private Label lblTricoParietal;
        private TextBox txtTricoParietalAnagena;
        private TextBox txtTricoParietalCatagena;
        private TextBox txtTricoParietalTelogena;

        private Label lblTricoOccipital;
        private TextBox txtTricoOccipitalAnagena;
        private TextBox txtTricoOccipitalCatagena;
        private TextBox txtTricoOccipitalTelogena;

        private Label lblAnagenaHead;
        private Label lblCatagenaHead;
        private Label lblTelogenaHead;

        private Label lblObsTricograma;
        private TextBox txtObsTricograma;

        private GroupBox gbSeguimiento;
        private DataGridView dgvSeguimiento;
        private Button btnAddSeguimiento;
        private Button btnRemoveSeguimiento;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            tabControlPrincipal = new TabControl();
            tabFichaPre = new TabPage();
            tabManualAparato = new TabPage();
            tabMicroTricoSeg = new TabPage();
            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            // Form Settings
            Size = new Size(1000, 800);
            BackColor = Color.FromArgb(240, 242, 245);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ficha de Diagnóstico Capilar de Cliente";

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 85;
            pnlHeader.Location = new Point(0, 0);

            // lblTitulo
            lblTitulo.Text = "FICHA DE CLIENTE / ANÁLISIS CAPILAR";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            // lblSubtitulo
            lblSubtitulo.Text = "Cliente: Cargando...";
            lblSubtitulo.ForeColor = Color.FromArgb(243, 156, 18); // Gold/Orange highlight
            lblSubtitulo.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblSubtitulo.Location = new Point(25, 47);
            lblSubtitulo.AutoSize = true;

            pnlHeader.Controls.AddRange(new Control[] { lblTitulo, lblSubtitulo });

            // tabControlPrincipal
            tabControlPrincipal.Location = new Point(20, 105);
            tabControlPrincipal.Size = new Size(945, 570);
            tabControlPrincipal.Font = new Font("Segoe UI", 10F);

            // tabFichaPre
            tabFichaPre.Text = "📋 Ficha y Entrevista";
            tabFichaPre.BackColor = Color.FromArgb(248, 249, 250);
            ConfigurarTabFichaPre();

            // tabManualAparato
            tabManualAparato.Text = "🔍 Exploración y Aparatología";
            tabManualAparato.BackColor = Color.FromArgb(248, 249, 250);
            ConfigurarTabManualAparato();

            // tabMicroTricoSeg
            tabMicroTricoSeg.Text = "🔬 Microvisor, Tricograma y Historial";
            tabMicroTricoSeg.BackColor = Color.FromArgb(248, 249, 250);
            ConfigurarTabMicroTricoSeg();

            tabControlPrincipal.TabPages.AddRange(new TabPage[] { tabFichaPre, tabManualAparato, tabMicroTricoSeg });

            // btnGuardar
            btnGuardar.Text = "💾 Guardar Ficha";
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113); // Emerald green for save
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Size = new Size(200, 48);
            btnGuardar.Location = new Point(280, 690);
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar.Text = "Cancelar";
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.BackColor = Color.FromArgb(231, 76, 60); // Red
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Size = new Size(200, 48);
            btnCancelar.Location = new Point(510, 690);
            btnCancelar.Click += (s, e) => Close();

            // Add all base controls
            Controls.AddRange(new Control[] { pnlHeader, tabControlPrincipal, btnGuardar, btnCancelar });

            ResumeLayout(false);
        }

        private void ConfigurarTabFichaPre()
        {
            // gbDatosCliente
            gbDatosCliente = new GroupBox { Text = "1. DATOS DE CONTROL", Location = new Point(15, 15), Size = new Size(900, 75), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            lblFechaVisita = new Label { Text = "Fecha de primera visita:", Location = new Point(15, 33), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtFechaVisita = new TextBox { Location = new Point(180, 30), Size = new Size(200, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            gbDatosCliente.Controls.AddRange(new Control[] { lblFechaVisita, txtFechaVisita });

            // gbPreDiagnostico
            gbPreDiagnostico = new GroupBox { Text = "2. INFORMACIÓN PRE DIAGNÓSTICO (ENTREVISTA)", Location = new Point(15, 95), Size = new Size(900, 110), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            lblFrecuenciaLavado = new Label { Text = "Frecuencia de lavado (diario, alternos, etc):", Location = new Point(15, 33), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtFrecuenciaLavado = new TextBox { Location = new Point(320, 30), Size = new Size(550, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            lblProductos = new Label { Text = "Productos habitualmente utilizados:", Location = new Point(15, 71), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtProductos = new TextBox { Location = new Point(320, 68), Size = new Size(550, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            gbPreDiagnostico.Controls.AddRange(new Control[] { lblFrecuenciaLavado, txtFrecuenciaLavado, lblProductos, txtProductos });

            // gbEstadoCuero
            gbEstadoCuero = new GroupBox { Text = "3. ESTADO DEL CUERO CABELLUDO", Location = new Point(15, 210), Size = new Size(440, 160), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            chkCueroDescamacion = new CheckBox { Text = "Descamación", Location = new Point(20, 30), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroGrasa = new CheckBox { Text = "Exceso de grasa", Location = new Point(20, 60), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroCaida = new CheckBox { Text = "Caída anormal (hormonas, estrés, etc)", Location = new Point(20, 90), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroPicor = new CheckBox { Text = "Picor", Location = new Point(20, 120), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroNormal = new CheckBox { Text = "Normal", Location = new Point(280, 30), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroSeco = new CheckBox { Text = "Seco", Location = new Point(280, 60), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCueroGraso = new CheckBox { Text = "Graso", Location = new Point(280, 90), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            gbEstadoCuero.Controls.AddRange(new Control[] { chkCueroDescamacion, chkCueroGrasa, chkCueroCaida, chkCueroPicor, chkCueroNormal, chkCueroSeco, chkCueroGraso });

            // gbEstadoCabello
            gbEstadoCabello = new GroupBox { Text = "4. ESTADO DEL CABELLO", Location = new Point(475, 210), Size = new Size(440, 240), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            lblForma = new Label { Text = "Forma:", Location = new Point(15, 30), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkCabelloLiso = new CheckBox { Text = "Liso", Location = new Point(90, 29), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCabelloOndulado = new CheckBox { Text = "Ondulado", Location = new Point(175, 29), Font = new Font("Segoe UI", 9.5F), AutoSize = true };
            chkCabelloRizado = new CheckBox { Text = "Rizado", Location = new Point(280, 29), Font = new Font("Segoe UI", 9.5F), AutoSize = true };

            lblAlteraciones = new Label { Text = "Alteraciones:", Location = new Point(15, 70), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtAlteraciones = new TextBox { Location = new Point(140, 67), Size = new Size(270, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            lblColorMatiz = new Label { Text = "Color y matiz:", Location = new Point(15, 103), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtColorMatiz = new TextBox { Location = new Point(140, 100), Size = new Size(270, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            lblCanas = new Label { Text = "% Canas:", Location = new Point(15, 136), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtCanas = new TextBox { Location = new Point(140, 133), Size = new Size(270, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            lblGrosor = new Label { Text = "Grosor:", Location = new Point(15, 169), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtGrosor = new TextBox { Location = new Point(140, 166), Size = new Size(270, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            lblLongitud = new Label { Text = "Longitud:", Location = new Point(15, 202), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), AutoSize = true };
            txtLongitud = new TextBox { Location = new Point(140, 199), Size = new Size(270, 26), Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };

            gbEstadoCabello.Controls.AddRange(new Control[] {
                lblForma, chkCabelloLiso, chkCabelloOndulado, chkCabelloRizado,
                lblAlteraciones, txtAlteraciones, lblColorMatiz, txtColorMatiz,
                lblCanas, txtCanas, lblGrosor, txtGrosor, lblLongitud, txtLongitud
            });

            // gbObservaciones
            gbObservaciones = new GroupBox { Text = "5. OBSERVACIONES GENERALES", Location = new Point(15, 375), Size = new Size(440, 175), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            txtObservaciones = new TextBox { Location = new Point(15, 25), Size = new Size(410, 135), Multiline = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 9.5F, FontStyle.Regular) };
            gbObservaciones.Controls.Add(txtObservaciones);

            tabFichaPre.Controls.AddRange(new Control[] { gbDatosCliente, gbPreDiagnostico, gbEstadoCuero, gbEstadoCabello, gbObservaciones });
        }

        private void ConfigurarTabManualAparato()
        {
            // gbManualCuero
            gbManualCuero = new GroupBox { Text = "EXPLORACIÓN MANUAL DE CUERO CABELLUDO", Location = new Point(15, 15), Size = new Size(440, 245), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };

            lblPalpacion = new Label { Text = "Palpación:", Location = new Point(15, 28), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkPalpacionNormal = new CheckBox { Text = "Normal", Location = new Point(110, 27), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPalpacionHumedo = new CheckBox { Text = "Húmedo", Location = new Point(200, 27), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPalpacionUntuoso = new CheckBox { Text = "Untuoso", Location = new Point(290, 27), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblPresion = new Label { Text = "Presión:", Location = new Point(15, 63), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkPresionNormal = new CheckBox { Text = "Normal", Location = new Point(110, 62), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPresionDeficiente = new CheckBox { Text = "Deficiente", Location = new Point(200, 62), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblMovilizacion = new Label { Text = "Movilización:", Location = new Point(15, 98), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkMovilizacionAdherencia = new CheckBox { Text = "Adherencia", Location = new Point(110, 97), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkMovilizacionNo = new CheckBox { Text = "No adherencia", Location = new Point(200, 97), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblJaquet = new Label { Text = "Signo Jaquet:", Location = new Point(15, 133), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkJaquetPos = new CheckBox { Text = "Positivo", Location = new Point(110, 132), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkJaquetNeg = new CheckBox { Text = "Negativo", Location = new Point(200, 132), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblSaboraud = new Label { Text = "Saboraud:", Location = new Point(15, 168), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkSaboraudPos = new CheckBox { Text = "Positivo", Location = new Point(110, 167), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkSaboraudNeg = new CheckBox { Text = "Negativo", Location = new Point(200, 167), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblPapel = new Label { Text = "Test Papel:", Location = new Point(15, 203), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkPapelPos = new CheckBox { Text = "Positivo", Location = new Point(110, 202), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPapelNeg = new CheckBox { Text = "Negativo", Location = new Point(200, 202), Font = new Font("Segoe UI", 9F), AutoSize = true };

            gbManualCuero.Controls.AddRange(new Control[] {
                lblPalpacion, chkPalpacionNormal, chkPalpacionHumedo, chkPalpacionUntuoso,
                lblPresion, chkPresionNormal, chkPresionDeficiente,
                lblMovilizacion, chkMovilizacionAdherencia, chkMovilizacionNo,
                lblJaquet, chkJaquetPos, chkJaquetNeg,
                lblSaboraud, chkSaboraudPos, chkSaboraudNeg,
                lblPapel, chkPapelPos, chkPapelNeg
            });

            // gbManualTallo
            gbManualTallo = new GroupBox { Text = "EXPLORACIÓN MANUAL DE TALLO CAPILAR", Location = new Point(15, 275), Size = new Size(440, 275), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };

            lblTextura = new Label { Text = "Textura:", Location = new Point(15, 30), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkTexturaFinas = new CheckBox { Text = "Finas", Location = new Point(110, 29), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkTexturaGruesas = new CheckBox { Text = "Gruesas", Location = new Point(200, 29), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblPuntas = new Label { Text = "Puntas:", Location = new Point(15, 75), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkPuntasAbiertas = new CheckBox { Text = "Abiertas", Location = new Point(110, 74), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPuntasCerradas = new CheckBox { Text = "Cerradas", Location = new Point(200, 74), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblPull = new Label { Text = "Pull-test:", Location = new Point(15, 120), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkPullPos = new CheckBox { Text = "Positivo", Location = new Point(110, 119), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkPullNeg = new CheckBox { Text = "Negativo", Location = new Point(200, 119), Font = new Font("Segoe UI", 9F), AutoSize = true };

            lblDeslizar = new Label { Text = "Deslizar:", Location = new Point(15, 165), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), AutoSize = true };
            chkDeslizarAlta = new CheckBox { Text = "Alta", Location = new Point(110, 164), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkDeslizarMedia = new CheckBox { Text = "Media", Location = new Point(200, 164), Font = new Font("Segoe UI", 9F), AutoSize = true };
            chkDeslizarNinguna = new CheckBox { Text = "Ninguna", Location = new Point(290, 164), Font = new Font("Segoe UI", 9F), AutoSize = true };

            gbManualTallo.Controls.AddRange(new Control[] {
                lblTextura, chkTexturaFinas, chkTexturaGruesas,
                lblPuntas, chkPuntasAbiertas, chkPuntasCerradas,
                lblPull, chkPullPos, chkPullNeg,
                lblDeslizar, chkDeslizarAlta, chkDeslizarMedia, chkDeslizarNinguna
            });

            // gbAparatologia
            gbAparatologia = new GroupBox { Text = "EXPLORACIÓN APARATOLOG\u00CDA DE CUERO CABELLUDO", Location = new Point(475, 15), Size = new Size(440, 535), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };

            lblCorneometro = new Label { Text = "Corneómetro:", Location = new Point(15, 25), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            chkCorneoMuyDes = new CheckBox { Text = "<30 Deshid.", Location = new Point(110, 23), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkCorneoDes = new CheckBox { Text = "30-40 Desh.", Location = new Point(200, 23), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkCorneoNormal = new CheckBox { Text = "40-50 Norm.", Location = new Point(290, 23), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkCorneoMuyHid = new CheckBox { Text = ">50 Hidrat.", Location = new Point(110, 48), Font = new Font("Segoe UI", 8.5F), AutoSize = true };

            lblSebometro = new Label { Text = "Sebómetro:", Location = new Point(15, 80), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            chkSeboSeco = new CheckBox { Text = "<50 Seco", Location = new Point(110, 78), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkSeboNormal = new CheckBox { Text = "50-100 Nor", Location = new Point(200, 78), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkSeboGraso = new CheckBox { Text = "100-200 Gr", Location = new Point(290, 78), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkSeboSeborrea = new CheckBox { Text = ">200 Sebor", Location = new Point(110, 103), Font = new Font("Segoe UI", 8.5F), AutoSize = true };

            lblPh = new Label { Text = "Medidor pH:", Location = new Point(15, 135), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            chkPhNormal = new CheckBox { Text = "4,5 - 5,5", Location = new Point(110, 133), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkPhAlto = new CheckBox { Text = "> 6", Location = new Point(200, 133), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkPhBajo = new CheckBox { Text = "< 4,5", Location = new Point(290, 133), Font = new Font("Segoe UI", 8.5F), AutoSize = true };

            lblWood = new Label { Text = "Luz de Wood:", Location = new Point(15, 170), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            chkWoodAmarillo = new CheckBox { Text = "Amarillo", Location = new Point(110, 168), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodVioClaro = new CheckBox { Text = "Violeta Cl", Location = new Point(200, 168), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodVioOscuro = new CheckBox { Text = "Violeta Os", Location = new Point(290, 168), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodAzul = new CheckBox { Text = "Azul", Location = new Point(110, 193), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodBlanco = new CheckBox { Text = "Blanco", Location = new Point(200, 193), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodOscuro = new CheckBox { Text = "Oscuro", Location = new Point(290, 193), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkWoodDebil = new CheckBox { Text = "C. Débil", Location = new Point(110, 218), Font = new Font("Segoe UI", 8.5F), AutoSize = true };

            lblMicrocamara = new Label { Text = "Microcámara:", Location = new Point(15, 255), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            chkMicroSueltas = new CheckBox { Text = "Esc. Sueltas", Location = new Point(110, 253), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroPegadas = new CheckBox { Text = "Esc. Pegad.", Location = new Point(210, 253), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroEritema = new CheckBox { Text = "Eritema", Location = new Point(310, 253), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroGrasa = new CheckBox { Text = "Grasa", Location = new Point(110, 278), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroMini = new CheckBox { Text = "Miniaturiz.", Location = new Point(210, 278), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroObstruccion = new CheckBox { Text = "Obstrucción", Location = new Point(310, 278), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            chkMicroDebil = new CheckBox { Text = "C. Débil", Location = new Point(110, 303), Font = new Font("Segoe UI", 8.5F), AutoSize = true };

            lblObsAparatologia = new Label { Text = "Observaciones de Aparatología:", Location = new Point(15, 345), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            txtObsAparatologia = new TextBox { Location = new Point(15, 370), Size = new Size(410, 145), Multiline = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 9F, FontStyle.Regular) };

            gbAparatologia.Controls.AddRange(new Control[] {
                lblCorneometro, chkCorneoMuyDes, chkCorneoDes, chkCorneoNormal, chkCorneoMuyHid,
                lblSebometro, chkSeboSeco, chkSeboNormal, chkSeboGraso, chkSeboSeborrea,
                lblPh, chkPhNormal, chkPhAlto, chkPhBajo,
                lblWood, chkWoodAmarillo, chkWoodVioClaro, chkWoodVioOscuro, chkWoodAzul, chkWoodBlanco, chkWoodOscuro, chkWoodDebil,
                lblMicrocamara, chkMicroSueltas, chkMicroPegadas, chkMicroEritema, chkMicroGrasa, chkMicroMini, chkMicroObstruccion, chkMicroDebil,
                lblObsAparatologia, txtObsAparatologia
            });

            tabManualAparato.Controls.AddRange(new Control[] { gbManualCuero, gbManualTallo, gbAparatologia });
        }

        private void ConfigurarTabMicroTricoSeg()
        {
            // gbMicrovisor
            gbMicrovisor = new GroupBox { Text = "EXPLORACIÓN MICROVISOR TALLO CAPILAR", Location = new Point(15, 10), Size = new Size(440, 275), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            lblAnomalias = new Label { Text = "Anomalías:", Location = new Point(15, 23), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), AutoSize = true };
            chkAnomTricorrexis = new CheckBox { Text = "Tricorrexis N.", Location = new Point(95, 21), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkAnomMonilethrix = new CheckBox { Text = "Monilethrix", Location = new Point(205, 21), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkAnomPiliTorti = new CheckBox { Text = "Pili torti", Location = new Point(310, 21), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkAnomPiliBifur = new CheckBox { Text = "Pili bifur.", Location = new Point(95, 43), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkAnomTricInvag = new CheckBox { Text = "Tricorr. Invag", Location = new Point(205, 43), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkAnomTricotio = new CheckBox { Text = "Tricotiodis.", Location = new Point(310, 43), Font = new Font("Segoe UI", 8F), AutoSize = true };

            lblDano = new Label { Text = "Daño Estruct:", Location = new Point(15, 80), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), AutoSize = true };
            chkDanoCuticula = new CheckBox { Text = "Cutícula lev.", Location = new Point(95, 78), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoPuntas = new CheckBox { Text = "Puntas abier.", Location = new Point(205, 78), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoTricoNodosa = new CheckBox { Text = "Tricorrexis N.", Location = new Point(310, 78), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoTricoclasia = new CheckBox { Text = "Tricoclasia", Location = new Point(95, 100), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoTriconodosis = new CheckBox { Text = "Triconodosis", Location = new Point(205, 100), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoTricolomania = new CheckBox { Text = "Tricoloman.", Location = new Point(310, 100), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoBayoneta = new CheckBox { Text = "P. Bayoneta", Location = new Point(95, 122), Font = new Font("Segoe UI", 8F), AutoSize = true };
            chkDanoEnfundado = new CheckBox { Text = "P. Enfundado", Location = new Point(205, 122), Font = new Font("Segoe UI", 8F), AutoSize = true };

            lblObsMicrovisor = new Label { Text = "Observaciones Microvisor:", Location = new Point(15, 160), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), AutoSize = true };
            txtObsMicrovisor = new TextBox { Location = new Point(15, 182), Size = new Size(410, 80), Multiline = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 8.5F) };

            gbMicrovisor.Controls.AddRange(new Control[] {
                lblAnomalias, chkAnomTricorrexis, chkAnomMonilethrix, chkAnomPiliTorti, chkAnomPiliBifur, chkAnomTricInvag, chkAnomTricotio,
                lblDano, chkDanoCuticula, chkDanoPuntas, chkDanoTricoNodosa, chkDanoTricoclasia, chkDanoTriconodosis, chkDanoTricolomania, chkDanoBayoneta, chkDanoEnfundado,
                lblObsMicrovisor, txtObsMicrovisor
            });

            // gbTricograma
            gbTricograma = new GroupBox { Text = "TRICOCOGRAMA", Location = new Point(475, 10), Size = new Size(440, 275), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            lblAnagenaHead = new Label { Text = "Anágena", Location = new Point(160, 20), Font = new Font("Segoe UI", 8F, FontStyle.Bold), Size = new Size(70, 15) };
            lblCatagenaHead = new Label { Text = "Catágena", Location = new Point(250, 20), Font = new Font("Segoe UI", 8F, FontStyle.Bold), Size = new Size(70, 15) };
            lblTelogenaHead = new Label { Text = "Telógena", Location = new Point(340, 20), Font = new Font("Segoe UI", 8F, FontStyle.Bold), Size = new Size(70, 15) };

            lblTricoFrontal = new Label { Text = "Frontal:", Location = new Point(15, 48), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            txtTricoFrontAnagena = new TextBox { Location = new Point(150, 45), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoFrontCatagena = new TextBox { Location = new Point(240, 45), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoFrontTelogena = new TextBox { Location = new Point(330, 45), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };

            lblTricoTempIzq = new Label { Text = "Temporal Izq:", Location = new Point(15, 78), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            txtTricoTempIzqAnagena = new TextBox { Location = new Point(150, 75), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoTempIzqCatagena = new TextBox { Location = new Point(240, 75), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoTempIzqTelogena = new TextBox { Location = new Point(330, 75), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };

            lblTricoTempDcho = new Label { Text = "Temporal Dch:", Location = new Point(15, 108), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            txtTricoTempDchoAnagena = new TextBox { Location = new Point(150, 105), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoTempDchoCatagena = new TextBox { Location = new Point(240, 105), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoTempDchoTelogena = new TextBox { Location = new Point(330, 105), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };

            lblTricoParietal = new Label { Text = "Parietal:", Location = new Point(15, 138), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            txtTricoParietalAnagena = new TextBox { Location = new Point(150, 135), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoParietalCatagena = new TextBox { Location = new Point(240, 135), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoParietalTelogena = new TextBox { Location = new Point(330, 135), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };

            lblTricoOccipital = new Label { Text = "Occipital:", Location = new Point(15, 168), Font = new Font("Segoe UI", 8.5F), AutoSize = true };
            txtTricoOccipitalAnagena = new TextBox { Location = new Point(150, 165), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoOccipitalCatagena = new TextBox { Location = new Point(240, 165), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };
            txtTricoOccipitalTelogena = new TextBox { Location = new Point(330, 165), Size = new Size(75, 23), Font = new Font("Segoe UI", 8.5F) };

            lblObsTricograma = new Label { Text = "Observaciones Tricograma:", Location = new Point(15, 198), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), AutoSize = true };
            txtObsTricograma = new TextBox { Location = new Point(15, 218), Size = new Size(410, 44), Multiline = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 8.5F) };

            gbTricograma.Controls.AddRange(new Control[] {
                lblAnagenaHead, lblCatagenaHead, lblTelogenaHead,
                lblTricoFrontal, txtTricoFrontAnagena, txtTricoFrontCatagena, txtTricoFrontTelogena,
                lblTricoTempIzq, txtTricoTempIzqAnagena, txtTricoTempIzqCatagena, txtTricoTempIzqTelogena,
                lblTricoTempDcho, txtTricoTempDchoAnagena, txtTricoTempDchoCatagena, txtTricoTempDchoTelogena,
                lblTricoParietal, txtTricoParietalAnagena, txtTricoParietalCatagena, txtTricoParietalTelogena,
                lblTricoOccipital, txtTricoOccipitalAnagena, txtTricoOccipitalCatagena, txtTricoOccipitalTelogena,
                lblObsTricograma, txtObsTricograma
            });

            // gbSeguimiento
            gbSeguimiento = new GroupBox { Text = "SEGUIMIENTO DE LOS SERVICIOS", Location = new Point(15, 290), Size = new Size(900, 240), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };

            dgvSeguimiento = new DataGridView
            {
                Location = new Point(15, 28),
                Size = new Size(730, 195),
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                Font = new Font("Segoe UI", 9F)
            };

            // Setup DataGridView Columns
            dgvSeguimiento.Columns.Add("ColFecha", "📅 Fecha");
            dgvSeguimiento.Columns[0].Width = 150;
            dgvSeguimiento.Columns.Add("ColDatosTecnicos", "🔧 Datos Técnicos");

            btnAddSeguimiento = new Button
            {
                Text = "➕ Añadir Fila",
                Location = new Point(760, 28),
                Size = new Size(125, 38),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddSeguimiento.FlatAppearance.BorderSize = 0;
            btnAddSeguimiento.Click += btnAddSeguimiento_Click;

            btnRemoveSeguimiento = new Button
            {
                Text = "➖ Eliminar",
                Location = new Point(760, 78),
                Size = new Size(125, 38),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRemoveSeguimiento.FlatAppearance.BorderSize = 0;
            btnRemoveSeguimiento.Click += btnRemoveSeguimiento_Click;

            gbSeguimiento.Controls.AddRange(new Control[] { dgvSeguimiento, btnAddSeguimiento, btnRemoveSeguimiento });

            tabMicroTricoSeg.Controls.AddRange(new Control[] { gbMicrovisor, gbTricograma, gbSeguimiento });
        }
    }
}
