using CadastroBiblioteca;
using System.Windows.Forms;

namespace Decimo_primeiro_Projeto
{
    public partial class Form1 : Form
    {
        BaseDeDados baseDeDados;
        public Form1()
        {
            InitializeComponent();
            baseDeDados = new BaseDeDados("BaseDeDados.xml");
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            CadastroPessoa cadastroPessoa = new CadastroPessoa(textBoxNomeCompleto.Text, textBoxNumeroDocumento.Text, Convert.ToDateTime(textBoxDataNascimento.Text), textBoxNomeRua.Text, Convert.ToUInt32(textBoxNumeroCasa.Text));
            baseDeDados.AdicionarPessoa(cadastroPessoa);
            MessageBox.Show("Usuário cadastrado com sucesso", "Cadastro concluido");
        }

        private void buttonBusca_Click(object sender, EventArgs e)
        {
            List<CadastroPessoa> listaPessoas = baseDeDados.PesquisaPessoaPorDoc(textBoxBuscaNumeroDocumento.Text);
            if(listaPessoas != null && listaPessoas.Count > 0)
            {
                labelNomeCompleto.Text = listaPessoas[0].Nome;
                labelDataNascimento.Text = listaPessoas[0].DataDeNascimento.ToString();
                labelNomeRua.Text = listaPessoas[0].NomeDaRua;
                labelNumeroCasa.Text = Convert.ToString(listaPessoas[0]);
            }
            else
            {
                MessageBox.Show("Usuário não localizado", "Exceção");
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            List<CadastroPessoa> listaPessoas = baseDeDados.RemoverPessoaPorDoc(textBoxBuscaNumeroDocumento.Text);
            if( listaPessoas != null && listaPessoas .Count > 0 )
            {
                labelNomeCompleto.Text = listaPessoas[0].Nome;
                labelDataNascimento.Text = listaPessoas[0].DataDeNascimento.ToString();
                labelNomeRua.Text = listaPessoas[0].NomeDaRua;
                labelNumeroCasa.Text = Convert.ToString(listaPessoas[0]);
                MessageBox.Show("Usuário removido com sucesso", "Usuário removido");
            }
            else
            {
                MessageBox.Show("Usuário não localizado", "Exceção");
            }
        }
    }
}
