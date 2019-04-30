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
        /// <summary>
        /// cierra el programa al hacer click en el boton cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// convierte en binario el valor del lblResultado.text o entrega un 
        /// mensaje de error si el valor es invalido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConverBinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Realiza la operacion deseada
        /// </summary>
        /// <param name="numero1">valor del numero 1</param>
        /// <param name="numero2">valor del numero 2</param>
        /// <param name="operador">valor del operando</param>
        /// <returns>Devuelve el resultado de la opercion deseada</returns>
        private double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
        /// <summary>
        /// Muesta el resultado de la operacion en el lblResultado.text 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text =Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }
        /// <summary>
        /// limpia los valores de todos los operandos 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }
        /// <summary>
        /// convierte en decimal el valor del lblResultado.text o entrega un 
        /// mensaje de error si el valor es invalido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConverDecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);            
        }
    }
}
