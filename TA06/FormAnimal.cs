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
    public partial class FormAnimal : Form
    {
        String id;
        private AnimalService animalService = new AnimalService();

        public FormAnimal(String id)
        {
            InitializeComponent();
            this.id = id;
            MostrarAnimales(animalService.ListarTodo(id));
        }

        private void MostrarAnimales(List<Animal> animales)
        {
            dgAnimales.DataSource = null;
            if (animales.Count == 0)
            {
                return;
            }
            else
            {
                dgAnimales.DataSource = animales;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validación de campos
            if(tbCodigo.Text == "" || tbNombre.Text == "" || tbFamilia.Text == "" || tbEdad.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            //Creación del objeto
            Animal animal = new Animal()
            {
                Codigo = tbCodigo.Text,
                Nombre = tbNombre.Text,
                Familia = tbFamilia.Text,
                Edad = int.Parse(tbEdad.Text)
            };

            //Registro de animal
            bool registrado = animalService.Registrar(id, animal);
            if(!registrado)
            {
                MessageBox.Show("Ingrese un código diferente");
                return;
            }

            MostrarAnimales(animalService.ListarTodo(id));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
