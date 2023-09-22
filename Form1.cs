using ListaSimpleCS.Clases;

namespace ListaSimpleCS
{
    public partial class Form1 : Form
    {
        //Comentario para cambio
        ListaSimple Lindek_List;
        public Form1()
        {
            InitializeComponent();
            Lindek_List = new ListaSimple();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Nodo MiNodo = new Nodo();
            MiNodo.Id = Lindek_List.NextId;
            MiNodo.Name = txtNombre.Text;
            Lindek_List.Add(MiNodo);
            StringToListBox(Lindek_List.ToString2(), listLista);
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int b = 1;
            Lindek_List.Remove(b);
            listLista.Items.Add(Lindek_List.ToString2());
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Lindek_List.Clear();
            int length = int.Parse(txtNumNodos.Text);
            for (int i = 0; i < length; i++)
            {
                Nodo newnode = new Nodo();
                newnode.Id = i + 1;
                newnode.Name = "test" + (i + 1);
                Lindek_List.Add(newnode);
            }
            StringToListBox(Lindek_List.ToString2(), listLista);
        }

        private void StringToListBox(string[] dataArray, ListBox list1)
        {
            list1.Items.Clear();
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (dataArray[i] == null)
                {
                    MessageBox.Show("Item array is null");
                    continue;
                }
                list1.Items.Add(dataArray[i]);
            }
        }
    }
}