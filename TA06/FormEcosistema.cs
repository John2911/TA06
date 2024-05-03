using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TA06.entities;
using TA06.services;

namespace TA06
{
    public partial class FormEcosistema : Form
    {
        private EcosistemaService ecosistemaService = new EcosistemaService();

        public FormEcosistema()
        {
            InitializeComponent();
            MostrarEcosistemas(ecosistemaService.ListarTodo());
        }

        private void MostrarEcosistemas(List<Ecosistema> ecosistemas)
        {
            dgEcosistemas.DataSource = null;
            
            if(ecosistemas.Count == 0)
            {
                return;
            }
            else
            {
                dgEcosistemas.DataSource = ecosistemas;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validación de campos
            if(tbId.Text == "" || tbNombre.Text == "" || tbArea.Text == "" || tbAforo.Text == "" )
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            //Creación del objeto
            Ecosistema ecosistema = new Ecosistema()
            {
                Id = tbId.Text,
                Nombre = tbNombre.Text,
                Area = double.Parse(tbArea.Text),
                Aforo = int.Parse(tbAforo.Text),
                Animales = new List<Animal>()
            };

            //Registro del ecosistema
            bool registrado = ecosistemaService.Registrar(ecosistema);
            if(!registrado)
            {
                MessageBox.Show("Ingrese un Id distinto");
                return;
            }

            //Mostramos
            MostrarEcosistemas(ecosistemaService.ListarTodo());
        }

        private void btnVerAnimales_Click(object sender, EventArgs e)
        {
            if(dgEcosistemas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ecosistema");
                return;
            }

            String id = dgEcosistemas.SelectedRows[0].Cells[0].Value.ToString();

            FormAnimal formAnimal = new FormAnimal(id);
            formAnimal.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte();
            form.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
