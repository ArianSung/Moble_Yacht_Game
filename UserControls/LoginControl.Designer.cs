namespace Moble_Yacht_Game.UserControls
{
    partial class LoginControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLogin = new Panel();
            linkFindPassword = new LinkLabel();
            linkFindId = new LinkLabel();
            btnGoToRegister = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            picGameLogo = new PictureBox();
            pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGameLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(linkFindPassword);
            pnlLogin.Controls.Add(linkFindId);
            pnlLogin.Controls.Add(btnGoToRegister);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Location = new Point(64, 255);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(401, 153);
            pnlLogin.TabIndex = 1;
            // 
            // linkFindPassword
            // 
            linkFindPassword.AutoSize = true;
            linkFindPassword.Location = new Point(153, 104);
            linkFindPassword.Name = "linkFindPassword";
            linkFindPassword.Size = new Size(83, 15);
            linkFindPassword.TabIndex = 3;
            linkFindPassword.TabStop = true;
            linkFindPassword.Text = "비밀번호 찾기";
            // 
            // linkFindId
            // 
            linkFindId.AutoSize = true;
            linkFindId.Location = new Point(76, 104);
            linkFindId.Name = "linkFindId";
            linkFindId.Size = new Size(71, 15);
            linkFindId.TabIndex = 3;
            linkFindId.TabStop = true;
            linkFindId.Text = "아이디 찾기";
            // 
            // btnGoToRegister
            // 
            btnGoToRegister.FlatStyle = FlatStyle.Flat;
            btnGoToRegister.Location = new Point(255, 80);
            btnGoToRegister.Name = "btnGoToRegister";
            btnGoToRegister.Size = new Size(119, 39);
            btnGoToRegister.TabIndex = 2;
            btnGoToRegister.Text = "회원가입";
            btnGoToRegister.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(255, 35);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(119, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(73, 75);
            txtPassword.MaxLength = 20;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(163, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(73, 36);
            txtUsername.MaxLength = 15;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(163, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 78);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(55, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "비밀번호";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(24, 39);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(43, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "아이디";
            // 
            // picGameLogo
            // 
            picGameLogo.Image = Properties.Resources.Dice;
            picGameLogo.Location = new Point(104, 53);
            picGameLogo.Name = "picGameLogo";
            picGameLogo.Size = new Size(300, 150);
            picGameLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picGameLogo.TabIndex = 0;
            picGameLogo.TabStop = false;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLogin);
            Controls.Add(picGameLogo);
            Name = "LoginControl";
            Size = new Size(1280, 710);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGameLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblPassword;
        private Label lblUsername;
        private Button btnGoToRegister;
        private Button btnLogin;
        private LinkLabel linkFindPassword;
        private LinkLabel linkFindId;
        private PictureBox picGameLogo;
    }
}
