using Moble_Yacht_Game.Helpers;
using System;
using System.Collections.Generic;


namespace Moble_Yacht_Game
{
    public partial class RegisterForm : Form
    {

        // --- 이벤트 선언 ---


        // --- 필드 선언 ---
        bool isUsernameChecked = false;
        


        public RegisterForm()
        {
            InitializeComponent();

            // --- 이벤트 핸들러 연결 ---

            // Form Events
            this.Load += RegisterForm_Load;

            // Panel Register
            btnCheckUsername.Click += BtnCheckUsername_Click;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            btnSendVerification.Click += BtnSendVerification_Click;
            btnConfirmVerification.Click += BtnConfirmVerification_Click;

            // Panel UserProfile
            btnCheckNickname.Click += BtnCheckNickname_Click;
            btnUploadImage.Click += BtnUploadImage_Click;

            // Panel Buttons
            btnBack.Click += BtnBack_Click;
            btnCancel.Click += BtnCancel_Click;
            btnNextOrRegister.Click += BtnNextOrRegister_Click;


        }

        private void RegisterForm_Load(object? sender, EventArgs e)
        {

            // Form First Settings(폼 초기 설정)
            FirstForm_Load();
        }

        #region ===== Panel Register =====

        private void BtnConfirmVerification_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSendVerification_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCheckUsername_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ===== UserProfile ===== 

        private void BtnUploadImage_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCheckNickname_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ===== Panel Buttons =====

        private void BtnNextOrRegister_Click(object? sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            panelButtons.Visible = true;

            btnBack.Enabled = true;
            btnNextOrRegister.Text = "가입";

        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
           this.Close();
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            FirstForm_Load();
        }

        #endregion

        private void FirstForm_Load()
        {
            // Form First Settings(폼 초기 설정)
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            panelButtons.Visible = true;
            btnBack.Enabled = false;
            btnNextOrRegister.Text = "다음";
            btnCancel.Text = "취소";
            this.AcceptButton = btnNextOrRegister;

            ObjectLocation_Set();
        }

        private void ObjectLocation_Set()
        {
            // 타이틀 설정
            UIHelper.CenterHorizontally(this, lblStep1Title);
            UIHelper.AlignToTop(this, lblStep1Title, 20);
            UIHelper.CenterHorizontally(this, lblStep2Title);
            UIHelper.AlignToTop(this, lblStep2Title, 20);

            // 공통 버튼 설정
            UIHelper.AlignToTopLeft(panelButtons, btnBack, 20);
            UIHelper.AlignToTopRight(panelButtons, btnNextOrRegister, 20);
            UIHelper.CenterHorizontally(panelButtons, btnCancel);
            UIHelper.AlignToBottom(panelButtons, btnCancel, 20);

        }

    }
}
