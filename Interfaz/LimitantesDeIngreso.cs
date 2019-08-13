using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    class LimitantesDeIngreso
    {
        //método para validar un email
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //método para ingresar únicamente letras
        public bool soloLetras(KeyPressEventArgs e)
        {
            bool Correct = false;
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    Correct = true;

                }
                
            }
            catch (Exception)
            {
            }
            return Correct;
        }
        //Para el ingreso de sólo números
        public bool soloNumeros(KeyPressEventArgs e)
        {
            bool Correct = false;
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    Correct = true;

                }
                
            }
            catch (Exception)
            {
            }
            return Correct;
        }

        public bool soloNumerosyPuntos(KeyPressEventArgs e)
        {
            bool Correct = false;
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    Correct = true;

                }

            }
            catch (Exception)
            {
            }
            return Correct;
        }
    }
}
