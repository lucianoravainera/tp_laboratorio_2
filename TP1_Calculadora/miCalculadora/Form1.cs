using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace miCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            //this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.Items.Add("+"); //Agrego al combobox las opciones
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Este metodo limpia la pantalla.
        /// </summary>
        public void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }
        /// <summary>
        /// Recibe 2 numeros y el operador, llama al metodo estatico de Calculadora
        /// y retorna el resultado
        /// </summary>
        /// <param name="numero1">primer numero</param>
        /// <param name="numero2">segundo numero</param>
        /// <param name="operador">operador</param>
        /// <returns>resultado de la operacion</returns>
        public static double Operar(string numero1,string numero2,string operador)
        {
            double aux;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            aux = Calculadora.operar(n1, n2, operador);
            return aux;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero(lblResultado.Text);
            lblResultado.Text = aux.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            //lblResultado.Text = Convert.ToInt32(lblResultado.Text, 2).ToString();
            Numero aux = new Numero(lblResultado.Text);
            lblResultado.Text = aux.BinarioDecimal(lblResultado.Text);
        }
    }
}
