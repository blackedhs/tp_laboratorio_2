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

namespace WindowsFormsApp1
{
  public partial class FormCalculadora : Form
  {
    public FormCalculadora()
    {
      InitializeComponent();
    }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConverBinario_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            resultado = Numero.DecimalBinario(resultado);
            if (resultado == "Valor invalido")
                MessageBox.Show("Valor Invalido","Error",MessageBoxButtons.OK);
            else
                lblResultado.Text = resultado;
        }
        private double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text =""+ Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void btnConverDecimal_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            resultado =Numero.DecimalBinario(resultado);
            if (resultado == "Valor invalido")
                MessageBox.Show("Valor Invalido", "Error", MessageBoxButtons.OK);
            else
                lblResultado.Text = resultado;
        }
    }
}
