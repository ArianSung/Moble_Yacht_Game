namespace Moble_Yacht_Game
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlStep1 = new Panel();
            lnkViewTerms = new LinkLabel();
            chkAgreeToTerms = new CheckBox();
            lblPasswordConfirm = new Label();
            lblPasswordPolicy = new Label();
            lblResendTimer = new Label();
            lblVerificationStatus = new Label();
            lblVerificationCode = new Label();
            lblEmail = new Label();
            lblPasswordStatus = new Label();
            lblPasswordStrength = new Label();
            chkShowPassword = new CheckBox();
            btnConfirmVerification = new Button();
            btnSendVerification = new Button();
            btnCheckUsername = new Button();
            txtVerificationCode = new TextBox();
            txtEmail = new TextBox();
            txtPasswordConfirm = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblUsernameStatus = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            lblStep1Title = new Label();
            pnlStep2 = new Panel();
            btnUploadImage = new Button();
            btnCheckNickname = new Button();
            txtNickname = new TextBox();
            picProfileImage = new PictureBox();
            lblImageStatus = new Label();
            lblProfileImage = new Label();
            lblNicknameStatus = new Label();
            lblNickname = new Label();
            lblStep2Title = new Label();
            panelButtons = new Panel();
            btnNextOrRegister = new Button();
            btnBack = new Button();
            btnCancel = new Button();
            pnlStep1.SuspendLayout();
            pnlStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProfileImage).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStep1
            // 
            pnlStep1.Controls.Add(lnkViewTerms);
            pnlStep1.Controls.Add(chkAgreeToTerms);
            pnlStep1.Controls.Add(lblPasswordConfirm);
            pnlStep1.Controls.Add(lblPasswordPolicy);
            pnlStep1.Controls.Add(lblResendTimer);
            pnlStep1.Controls.Add(lblVerificationStatus);
            pnlStep1.Controls.Add(lblVerificationCode);
            pnlStep1.Controls.Add(lblEmail);
            pnlStep1.Controls.Add(lblPasswordStatus);
            pnlStep1.Controls.Add(lblPasswordStrength);
            pnlStep1.Controls.Add(chkShowPassword);
            pnlStep1.Controls.Add(btnConfirmVerification);
            pnlStep1.Controls.Add(btnSendVerification);
            pnlStep1.Controls.Add(btnCheckUsername);
            pnlStep1.Controls.Add(txtVerificationCode);
            pnlStep1.Controls.Add(txtEmail);
            pnlStep1.Controls.Add(txtPasswordConfirm);
            pnlStep1.Controls.Add(txtPassword);
            pnlStep1.Controls.Add(txtUsername);
            pnlStep1.Controls.Add(lblUsernameStatus);
            pnlStep1.Controls.Add(lblPassword);
            pnlStep1.Controls.Add(lblUsername);
            pnlStep1.Controls.Add(lblStep1Title);
            pnlStep1.Location = new Point(0, 0);
            pnlStep1.Name = "pnlStep1";
            pnlStep1.Size = new Size(434, 530);
            pnlStep1.TabIndex = 0;
            // 
            // lnkViewTerms
            // 
            lnkViewTerms.AutoSize = true;
            lnkViewTerms.Location = new Point(44, 473);
            lnkViewTerms.Name = "lnkViewTerms";
            lnkViewTerms.Size = new Size(59, 15);
            lnkViewTerms.TabIndex = 10;
            lnkViewTerms.TabStop = true;
            lnkViewTerms.Text = "약관 보기";
            // 
            // chkAgreeToTerms
            // 
            chkAgreeToTerms.AutoSize = true;
            chkAgreeToTerms.Location = new Point(44, 491);
            chkAgreeToTerms.Name = "chkAgreeToTerms";
            chkAgreeToTerms.Size = new Size(229, 19);
            chkAgreeToTerms.TabIndex = 11;
            chkAgreeToTerms.Text = "(필수) 서비스 이용약관에 동의합니다.";
            chkAgreeToTerms.UseVisualStyleBackColor = true;
            // 
            // lblPasswordConfirm
            // 
            lblPasswordConfirm.AutoSize = true;
            lblPasswordConfirm.Location = new Point(44, 213);
            lblPasswordConfirm.Name = "lblPasswordConfirm";
            lblPasswordConfirm.Size = new Size(83, 15);
            lblPasswordConfirm.TabIndex = 5;
            lblPasswordConfirm.Text = "비밀번호 확인";
            // 
            // lblPasswordPolicy
            // 
            lblPasswordPolicy.AutoSize = true;
            lblPasswordPolicy.Location = new Point(80, 185);
            lblPasswordPolicy.Name = "lblPasswordPolicy";
            lblPasswordPolicy.Size = new Size(190, 15);
            lblPasswordPolicy.TabIndex = 5;
            lblPasswordPolicy.Text = "영문, 숫자, 특수문자 포함 6~20자";
            // 
            // lblResendTimer
            // 
            lblResendTimer.AutoSize = true;
            lblResendTimer.Location = new Point(292, 385);
            lblResendTimer.Name = "lblResendTimer";
            lblResendTimer.Size = new Size(38, 15);
            lblResendTimer.TabIndex = 5;
            lblResendTimer.Text = "03:00";
            // 
            // lblVerificationStatus
            // 
            lblVerificationStatus.AutoSize = true;
            lblVerificationStatus.Location = new Point(44, 414);
            lblVerificationStatus.Name = "lblVerificationStatus";
            lblVerificationStatus.Size = new Size(71, 15);
            lblVerificationStatus.TabIndex = 5;
            lblVerificationStatus.Text = "상태 메시지";
            // 
            // lblVerificationCode
            // 
            lblVerificationCode.AutoSize = true;
            lblVerificationCode.Location = new Point(44, 361);
            lblVerificationCode.Name = "lblVerificationCode";
            lblVerificationCode.Size = new Size(55, 15);
            lblVerificationCode.TabIndex = 5;
            lblVerificationCode.Text = "인증번호";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(44, 300);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "이메일";
            // 
            // lblPasswordStatus
            // 
            lblPasswordStatus.AutoSize = true;
            lblPasswordStatus.Location = new Point(44, 261);
            lblPasswordStatus.Name = "lblPasswordStatus";
            lblPasswordStatus.Size = new Size(71, 15);
            lblPasswordStatus.TabIndex = 5;
            lblPasswordStatus.Text = "상태 메시지";
            // 
            // lblPasswordStrength
            // 
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.Location = new Point(44, 185);
            lblPasswordStrength.Name = "lblPasswordStrength";
            lblPasswordStrength.Size = new Size(31, 15);
            lblPasswordStrength.TabIndex = 5;
            lblPasswordStrength.Text = "약함";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(292, 161);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(102, 19);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "비밀번호 보기";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // btnConfirmVerification
            // 
            btnConfirmVerification.Location = new Point(186, 379);
            btnConfirmVerification.Name = "btnConfirmVerification";
            btnConfirmVerification.Size = new Size(85, 27);
            btnConfirmVerification.TabIndex = 9;
            btnConfirmVerification.Text = "인증 확인";
            btnConfirmVerification.UseVisualStyleBackColor = true;
            // 
            // btnSendVerification
            // 
            btnSendVerification.Location = new Point(292, 318);
            btnSendVerification.Name = "btnSendVerification";
            btnSendVerification.Size = new Size(85, 27);
            btnSendVerification.TabIndex = 7;
            btnSendVerification.Text = "인증번호 발송";
            btnSendVerification.UseVisualStyleBackColor = true;
            // 
            // btnCheckUsername
            // 
            btnCheckUsername.Location = new Point(292, 79);
            btnCheckUsername.Name = "btnCheckUsername";
            btnCheckUsername.Size = new Size(85, 27);
            btnCheckUsername.TabIndex = 1;
            btnCheckUsername.Text = "중복확인";
            btnCheckUsername.UseVisualStyleBackColor = true;
            // 
            // txtVerificationCode
            // 
            txtVerificationCode.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtVerificationCode.Location = new Point(44, 379);
            txtVerificationCode.Name = "txtVerificationCode";
            txtVerificationCode.Size = new Size(115, 27);
            txtVerificationCode.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(44, 318);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(227, 27);
            txtEmail.TabIndex = 6;
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordConfirm.Location = new Point(44, 231);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.Size = new Size(227, 27);
            txtPasswordConfirm.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(44, 155);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(227, 27);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(44, 79);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(227, 27);
            txtUsername.TabIndex = 0;
            // 
            // lblUsernameStatus
            // 
            lblUsernameStatus.AutoSize = true;
            lblUsernameStatus.Location = new Point(44, 109);
            lblUsernameStatus.Name = "lblUsernameStatus";
            lblUsernameStatus.Size = new Size(71, 15);
            lblUsernameStatus.TabIndex = 1;
            lblUsernameStatus.Text = "상태 메시지";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(44, 137);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(55, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "비밀번호";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(44, 61);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(43, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "아이디";
            // 
            // lblStep1Title
            // 
            lblStep1Title.AutoSize = true;
            lblStep1Title.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStep1Title.Location = new Point(162, 9);
            lblStep1Title.Name = "lblStep1Title";
            lblStep1Title.Size = new Size(109, 20);
            lblStep1Title.TabIndex = 0;
            lblStep1Title.Text = "회원가입 (1/2)";
            // 
            // pnlStep2
            // 
            pnlStep2.Controls.Add(btnUploadImage);
            pnlStep2.Controls.Add(btnCheckNickname);
            pnlStep2.Controls.Add(txtNickname);
            pnlStep2.Controls.Add(picProfileImage);
            pnlStep2.Controls.Add(lblImageStatus);
            pnlStep2.Controls.Add(lblProfileImage);
            pnlStep2.Controls.Add(lblNicknameStatus);
            pnlStep2.Controls.Add(lblNickname);
            pnlStep2.Controls.Add(lblStep2Title);
            pnlStep2.Location = new Point(0, 0);
            pnlStep2.Name = "pnlStep2";
            pnlStep2.Size = new Size(434, 530);
            pnlStep2.TabIndex = 1;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Location = new Point(276, 173);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(90, 29);
            btnUploadImage.TabIndex = 2;
            btnUploadImage.Text = "이미지 찾기...";
            btnUploadImage.UseVisualStyleBackColor = true;
            // 
            // btnCheckNickname
            // 
            btnCheckNickname.Location = new Point(277, 79);
            btnCheckNickname.Name = "btnCheckNickname";
            btnCheckNickname.Size = new Size(90, 29);
            btnCheckNickname.TabIndex = 1;
            btnCheckNickname.Text = "중복확인";
            btnCheckNickname.UseVisualStyleBackColor = true;
            // 
            // txtNickname
            // 
            txtNickname.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNickname.Location = new Point(56, 79);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(203, 29);
            txtNickname.TabIndex = 0;
            // 
            // picProfileImage
            // 
            picProfileImage.Location = new Point(56, 173);
            picProfileImage.Name = "picProfileImage";
            picProfileImage.Size = new Size(203, 203);
            picProfileImage.TabIndex = 1;
            picProfileImage.TabStop = false;
            // 
            // lblImageStatus
            // 
            lblImageStatus.AutoSize = true;
            lblImageStatus.Location = new Point(60, 385);
            lblImageStatus.Name = "lblImageStatus";
            lblImageStatus.Size = new Size(71, 15);
            lblImageStatus.TabIndex = 0;
            lblImageStatus.Text = "상태 메시지";
            // 
            // lblProfileImage
            // 
            lblProfileImage.AutoSize = true;
            lblProfileImage.Location = new Point(56, 155);
            lblProfileImage.Name = "lblProfileImage";
            lblProfileImage.Size = new Size(83, 15);
            lblProfileImage.TabIndex = 0;
            lblProfileImage.Text = "프로필 이미지";
            // 
            // lblNicknameStatus
            // 
            lblNicknameStatus.AutoSize = true;
            lblNicknameStatus.Location = new Point(56, 111);
            lblNicknameStatus.Name = "lblNicknameStatus";
            lblNicknameStatus.Size = new Size(71, 15);
            lblNicknameStatus.TabIndex = 0;
            lblNicknameStatus.Text = "상태 메시지";
            // 
            // lblNickname
            // 
            lblNickname.AutoSize = true;
            lblNickname.Location = new Point(56, 61);
            lblNickname.Name = "lblNickname";
            lblNickname.Size = new Size(43, 15);
            lblNickname.TabIndex = 0;
            lblNickname.Text = "닉네임";
            // 
            // lblStep2Title
            // 
            lblStep2Title.AutoSize = true;
            lblStep2Title.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStep2Title.Location = new Point(162, 9);
            lblStep2Title.Name = "lblStep2Title";
            lblStep2Title.Size = new Size(124, 20);
            lblStep2Title.TabIndex = 0;
            lblStep2Title.Text = "프로필 설정 (2/2)";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnNextOrRegister);
            panelButtons.Controls.Add(btnBack);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(0, 536);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(434, 116);
            panelButtons.TabIndex = 2;
            // 
            // btnNextOrRegister
            // 
            btnNextOrRegister.Location = new Point(332, 23);
            btnNextOrRegister.Name = "btnNextOrRegister";
            btnNextOrRegister.Size = new Size(75, 35);
            btnNextOrRegister.TabIndex = 1;
            btnNextOrRegister.Text = "다음";
            btnNextOrRegister.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(28, 23);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 35);
            btnBack.TabIndex = 0;
            btnBack.Text = "이전";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(180, 71);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 35);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 651);
            Controls.Add(panelButtons);
            Controls.Add(pnlStep1);
            Controls.Add(pnlStep2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegisterForm";
            pnlStep1.ResumeLayout(false);
            pnlStep1.PerformLayout();
            pnlStep2.ResumeLayout(false);
            pnlStep2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProfileImage).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStep1;
        private Panel pnlStep2;
        private Label lblPasswordConfirm;
        private Label lblPasswordPolicy;
        private Label lblPasswordStrength;
        private CheckBox chkShowPassword;
        private Button btnCheckUsername;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblStep1Title;
        private Label lblEmail;
        private Label lblPasswordStatus;
        private TextBox txtPasswordConfirm;
        private Label lblResendTimer;
        private Label lblVerificationStatus;
        private Label lblVerificationCode;
        private Button btnConfirmVerification;
        private Button btnSendVerification;
        private TextBox txtVerificationCode;
        private TextBox txtEmail;
        private LinkLabel lnkViewTerms;
        private CheckBox chkAgreeToTerms;
        private Label lblUsernameStatus;
        private Panel panelButtons;
        private Button btnNextOrRegister;
        private Button btnBack;
        private Button btnCancel;
        private Button btnUploadImage;
        private Button btnCheckNickname;
        private TextBox txtNickname;
        private PictureBox picProfileImage;
        private Label lblImageStatus;
        private Label lblProfileImage;
        private Label lblNicknameStatus;
        private Label lblNickname;
        private Label lblStep2Title;
    }
}
