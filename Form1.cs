using ListaSimpleCS.Clases;

namespace ListaSimpleCS
{
    public partial class Form1 : Form
    {
        ListaSimple Lindek_List;
        int nextAvailableId; // Contador para el próximo ID disponible
        private int? selectedNodeId; // Variable para almacenar el ID del nodo seleccionado

        public Form1()
        {
            InitializeComponent();
            Lindek_List = new ListaSimple();
            nextAvailableId = 1; // Inicializa el contador en 1
            InitializeListView();

            // Agrega el evento MouseDoubleClick al ListView
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
        }

        private void InitializeListView()
        {
            // Configura las columnas del ListView
            listView1.View = View.Details;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Name", 100);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Nodo MiNodo = new Nodo();

            if (selectedNodeId.HasValue)
            {
                // Si selectedNodeId tiene un valor, significa que estamos editando un nodo
                MiNodo.Id = selectedNodeId.Value; // Asigna el ID original
                selectedNodeId = null; // Limpia el valor para futuras inserciones
            }
            else
            {
                MiNodo.Id = nextAvailableId; // Asigna el próximo ID disponible
                nextAvailableId++; // Incrementa el contador
            }

            MiNodo.Name = txtNombre.Text;
            Lindek_List.Add(MiNodo);
            AddItemToListView(MiNodo);
            txtNombre.Clear();
            txtNombre.Focus();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                int id = int.Parse(item.SubItems[0].Text);
                Lindek_List.Remove(id);
                listView1.Items.Remove(item);
                // No incrementes nextAvailableId aquí para evitar la repetición de IDs
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Lindek_List.Clear();
            listView1.Items.Clear(); // Borra los elementos del ListView

            int length = int.Parse(txtNumNodos.Text);
            nextAvailableId = 1; // Reinicia el contador

            for (int i = 0; i < length; i++)
            {
                Nodo newnode = new Nodo();
                newnode.Id = nextAvailableId; // Asigna el próximo ID disponible
                newnode.Name = "test" + nextAvailableId;
                Lindek_List.Add(newnode);
                AddItemToListView(newnode);
                nextAvailableId++; // Incrementa el contador
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtén el elemento seleccionado
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Obtén el ID y el nombre del elemento seleccionado
                int id = int.Parse(selectedItem.SubItems[0].Text);
                string name = selectedItem.SubItems[1].Text;

                // Muestra el nombre en el TextBox de nombre
                txtNombre.Text = name;

                // Almacena el ID original en selectedNodeId
                selectedNodeId = id;

                // Elimina el nodo seleccionado de la lista
                Lindek_List.Remove(id);
                listView1.Items.Remove(selectedItem);
            }
        }
        private void AddItemToListView(Nodo nodo)
        {
            ListViewItem item = new ListViewItem(nodo.Id.ToString());
            item.SubItems.Add(nodo.Name);
            listView1.Items.Add(item);
        }
    }
}