using Escola_POO_BASE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Escola_POO_BASE.Telas
{
    public partial class TelaCadastroAluno : Form
    {       
        private Professor _userLogado;    
        private List<Aluno> _alunos;
        private Aluno _alunoSelecionado;
        public TelaCadastroAluno( Usuario userLogado)
        {
            InitializeComponent();

            try
            {
                _alunos = Usuario.BuscarUsuariosA().ConvertAll(u => (Aluno)u);
                _userLogado = (Professor)userLogado;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //Método de formulário que irá configurar o DgvUsuarios
        private void ConfiguraDgvUsuarios()
        {
            DgvUsuarios.Columns.Add("Id", "Matrícula");
            DgvUsuarios.Columns.Add("Nome", "Nome");
            DgvUsuarios.Columns.Add("DtNascimento", "Data Nascimento");
            DgvUsuarios.Columns.Add("DtMatricula", "Data Matrícula");
            DgvUsuarios.Columns.Add("Email", "e-mail");
            DgvUsuarios.Columns.Add("Ativo", "Ativo");
            //--------
            //Configuração dos alinhamentos de cada coluna do DgvUsuarios

            DgvUsuarios.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DgvUsuarios.Columns["DtNascimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["DtMatricula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvUsuarios.Columns["Ativo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DgvUsuarios.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DgvUsuarios.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvUsuarios.Columns["DtNascimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DgvUsuarios.Columns["DtMatricula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvUsuarios.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvUsuarios.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //Configuarar tamanho em altura das linhas
            DgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvUsuarios.ColumnHeadersHeight = 35;
            DgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Definindo uma cor para intercalar linhas
            DgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void CarregaDgvUsuarios(List<Aluno> alunos = null)
        {
            DgvUsuarios.Rows.Clear();            
            
            if (_userLogado.NivelAcesso != 1)
            {
                foreach (Aluno aluno in alunos == null ? _alunos : alunos)
                {
                    if(aluno.Ativo == true)
                    {
                        DgvUsuarios.Rows.Add(aluno.Id, aluno.Nome, aluno.DtNascimento.ToString("dd/MM/yyyy"), aluno.DtMatricula, aluno.Email);
                        BtnReativar.Visible = false;
                    }                                         
                }
            }
            else
            {
                foreach (Aluno aluno in alunos == null ? _alunos : alunos)
                {
                    DgvUsuarios.Rows.Add(aluno.Id, aluno.Nome, aluno.DtNascimento.ToString("dd/MM/yyyy"), aluno.DtMatricula, aluno.Email, aluno.Ativo);

                    if (!aluno.Ativo)
                    {
                        DgvUsuarios.Rows[DgvUsuarios.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                    }

                }
            }

        }

        private void LimparCampos()
        {
            LblId.Text = string.Empty;
            TxtEmail.Clear();
            TxtNome.Clear();
            DTPMatricula.Value = new DateTime(1990, 1, 1);
            DTPNascimento.Value = DateTime.Now;
            CBAtivo.Checked = true;
            CBAtivo.Enabled = false;
            DgvUsuarios.ClearSelection();
            BtnCadastrar.Enabled = true;
            BtnAlterar.Enabled = false;
            BtnReativar.Enabled = false;
            CbbBuscar.SelectedIndex = 0;
            BtnAlterar.BackColor = Color.Silver;
            BtnCadastrar.BackColor = Color.DarkOrange;
            BtnReativar.BackColor = Color.Silver;
            if (_userLogado.NivelAcesso != 1)
            {
                BtnReativar.Visible = false;
            }
            
        }
        
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Professor professor = (Professor)_userLogado;
               
                if (_userLogado.NivelAcesso == 1)
                {
                    Aluno aluno = new Aluno(0, TxtNome.Text, DTPNascimento.Value, DTPMatricula.Value, TxtEmail.Text, Crypto.Sha256("123"), true);
                    aluno.Cadastrar(_alunos);

                    CarregaDgvUsuarios();
                    LimparCampos();
                   
                }
                else
                {
                    BtnCadastrar.Enabled = false;
                    MessageBox.Show($"Você não possui permissão para tal ação!!!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch ( Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
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
                _alunoSelecionado = _alunos.Find(a => a.Id == (int)DgvUsuarios.SelectedRows[0].Cells[0].Value);                

                LblId.Text = _alunoSelecionado.Id.ToString();
                TxtNome.Text = _alunoSelecionado.Nome.ToString();
                TxtEmail.Text = _alunoSelecionado.Email.ToString();
                DTPMatricula.Value = _alunoSelecionado.DtMatricula;
                DTPNascimento.Value = _alunoSelecionado.DtNascimento;
                CBAtivo.Checked = _alunoSelecionado.Ativo;
                BtnCadastrar.Enabled = false;
                BtnAlterar.Enabled = true;
                BtnAlterar.BackColor = Color.DarkOrange;
                BtnCadastrar.BackColor = Color.Silver;

                if (_alunoSelecionado.Ativo == false)
                {
                    BtnReativar.BackColor = Color.DarkOrange;
                    BtnReativar.Enabled = true;
                }
                else if (_alunoSelecionado.Ativo == true)
                {
                    BtnReativar.BackColor = Color.Silver;
                    BtnReativar.Enabled = false;
                }
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
                _alunoSelecionado.Nome = TxtNome.Text;
                _alunoSelecionado.Email = TxtEmail.Text;
                _alunoSelecionado.DtNascimento = DTPNascimento.Value;
                _alunoSelecionado.DtMatricula = DTPMatricula.Value;

                _alunoSelecionado.Alterar(_alunos);
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
               if(_alunoSelecionado.Ativo == true)
               {
                    if (_userLogado.NivelAcesso == 1)
                    {
                        DialogResult dr = MessageBox.Show($"Você deseja remover o {_alunoSelecionado.Nome}?"
                                   , "Remover Aluno"
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            _alunoSelecionado.Ativo = false;
                            _alunoSelecionado.Deletar(_alunos);
                            CarregaDgvUsuarios();
                            LimparCampos();
                        }
                    }
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
            List<Aluno> ListaAlunosFiltrada = Aluno.Buscar(_alunos, CbbBuscar.SelectedIndex, TxtBuscar.Text);
            CarregaDgvUsuarios(ListaAlunosFiltrada);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.PerformClick();   
        }

        private void TelaCadastroAluno_Shown(object sender, EventArgs e)
        {
            TxtBuscar.Focus();
        }

        private void BtnReativar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Você deseja reativar o {_alunoSelecionado.Nome}?"
                                , "Reativar Aluno"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    _alunoSelecionado.Ativo = true;
                    _alunoSelecionado.Reativar(_alunos);
                    CarregaDgvUsuarios();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
