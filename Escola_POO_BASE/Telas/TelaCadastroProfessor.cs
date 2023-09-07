using Escola_POO_BASE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Telas
{
    public partial class TelaCadastroProfessor : Form
    {
        private Professor _userLogado;
        private List<Professor> _professores;
        private Professor _professorSelecionado;

        public TelaCadastroProfessor(Usuario userLogado)
        {
            InitializeComponent();

            try
            {
                _professores = Usuario.BuscarUsuariosP().ConvertAll(u => (Professor)u);
                _userLogado = (Professor)userLogado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfiguraDgvUsuarios()
        {
            DgvUsuarios.Columns.Add("Id", "NR Registro");
            DgvUsuarios.Columns.Add("Nome", "Nome");
            DgvUsuarios.Columns.Add("DtNascimento", "Data Nascimento");
            DgvUsuarios.Columns.Add("CPF", "CPF");
            DgvUsuarios.Columns.Add("Email", "e-mail");
            DgvUsuarios.Columns.Add("NivelAcesso", "Nível Acesso");
            DgvUsuarios.Columns.Add("Ativo", "Ativo");
            //--------
            //Configuração dos alinhamentos de cada coluna do DgvUsuarios

            DgvUsuarios.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DgvUsuarios.Columns["DtNascimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["CPF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["NivelAcesso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Ativo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DgvUsuarios.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DgvUsuarios.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvUsuarios.Columns["DtNascimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DgvUsuarios.Columns["CPF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvUsuarios.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvUsuarios.Columns["NivelAcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvUsuarios.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //Configuarar tamanho em altura das linhas
            DgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvUsuarios.ColumnHeadersHeight = 35;
            DgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Definindo uma cor para intercalar linhas
            DgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void CarregaDgvUsuarios(List<Professor> professores = null)
        {
            DgvUsuarios.Rows.Clear();

            foreach (Professor professor in professores == null ? _professores : professores)
            {
                DgvUsuarios.Rows.Add(professor.Id, professor.Nome, professor.DtNascimento.ToString("dd/MM/yyyy"), professor.CPF, professor.Email, professor.NivelAcesso, professor.Ativo);

                if (!professor.Ativo)
                {
                    DgvUsuarios.Rows[DgvUsuarios.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }

        }

        private void LimparCampos()
        {
            LblId.Text = string.Empty;
            TxtEmail.Clear();
            TxtNome.Clear();
            TxtCpf.Clear();
            DTPNascimento.Value = DateTime.Now;
            TxtNivelAcesso.Clear();
            CBAtivo.Checked = true;
            CBAtivo.Enabled = false;
            DgvUsuarios.ClearSelection();
            BtnCadastrar.Enabled = true;
            BtnAlterar.Enabled = false;
            CbbBuscar.SelectedIndex = 0;            

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Professor professor = (Professor)_userLogado;

                if (_userLogado.NivelAcesso == 1)
                {
                    Professor professor = new Professor(0, TxtNome.Text, DTPNascimento.Value, TxtCpf.Text, TxtEmail.Text, Crypto.Sha256("123"), Convert.ToInt32(TxtNivelAcesso.Text), true);
                    professor.Cadastrar(_professores);

                    CarregaDgvUsuarios();
                    LimparCampos();

                }
                else
                {
                    BtnCadastrar.Enabled = false;
                    MessageBox.Show($"Você não possui permissão para tal ação!!!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TelaCadastroProfessor_Load(object sender, EventArgs e)
        {

            try
            {
                ConfiguraDgvUsuarios();
                CarregaDgvUsuarios();
                LimparCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {

            if (DgvUsuarios.Rows.Count < 1 || DgvUsuarios.SelectedRows.Count < 1)
                return;

            try
            {
                _professorSelecionado = _professores.Find(a => a.Id == (int)DgvUsuarios.SelectedRows[0].Cells[0].Value);

                LblId.Text = _professorSelecionado.Id.ToString();
                TxtNome.Text = _professorSelecionado.Nome.ToString();
                TxtEmail.Text = _professorSelecionado.Email.ToString();
                TxtCpf.Text = _professorSelecionado.CPF;
                DTPNascimento.Value = _professorSelecionado.DtNascimento;
                TxtNivelAcesso.Text = _professorSelecionado.NivelAcesso.ToString();
                CBAtivo.Checked = _professorSelecionado.Ativo;
                BtnCadastrar.Enabled = false;
                BtnAlterar.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                _professorSelecionado.Nome = TxtNome.Text;
                _professorSelecionado.Email = TxtEmail.Text;
                _professorSelecionado.DtNascimento = DTPNascimento.Value;
                _professorSelecionado.NivelAcesso = Convert.ToInt32(TxtNivelAcesso.Text);

                _professorSelecionado.Alterar(_professores);
                CarregaDgvUsuarios();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Você deseja remover o {_professorSelecionado.Nome}?"
                                , "Remover Aluno"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    _professorSelecionado.Ativo = false;
                    _professorSelecionado.Deletar(_professores);
                    CarregaDgvUsuarios();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == DgvUsuarios.Columns["Ativo"].Index && e.RowIndex >= 0)
            //{
            //     DataGridViewRow row = DgvUsuarios.Rows[e.RowIndex];
            //     bool ativo = Convert.ToBoolean(row.Cells["Ativo"].Value);

            //     if (ativo == false)
            //     {
            //         row.DefaultCellStyle.BackColor = Color.LightCoral;
            //     }
            //}

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Professor> ListaProfessoresFiltrada = Professor.Buscar(_professores, CbbBuscar.SelectedIndex, Txtbuscar.Text);
            CarregaDgvUsuarios(ListaProfessoresFiltrada);
        }

        private void TelaCadastroProfessor_Shown(object sender, EventArgs e)
        {
            Txtbuscar.Focus();
        }

        private void Txtbuscar_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.PerformClick();
        }

       
    }
}
