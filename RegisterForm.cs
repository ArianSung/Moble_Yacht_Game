using Moble_Yacht_Game.Database.Handlers;
using Moble_Yacht_Game.Helpers;
using Moble_Yacht_Game.Managers;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Moble_Yacht_Game
{
    /// <summary>
    /// 회원가입 절차를 담당하는 폼 클래스입니다.
    /// 단계별 UI 전환, 사용자 입력 유효성 검사, 이미지 업로드 및 최종 가입 요청을 처리합니다.
    /// </summary>
    public partial class RegisterForm : Form
    {
        #region --- 이벤트 선언 ---

        /// <summary>
        /// 회원가입이 성공적으로 완료되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event Action RegisterSuccess;

        #endregion

        #region --- 필드 선언 ---

        // 아이디 중복 확인 여부
        private bool isUsernameChecked = false;
        // 닉네임 중복 확인 여부
        private bool isNicknameChecked = false;
        // 이메일 인증 여부(임시 구현)
        private bool isEmailVerified = false;
        // 선택한 프로필 이미지 경로
        private string profileImagePath = null;

        #endregion

        /// <summary>
        /// RegisterForm의 생성자입니다. 컨트롤 초기화 및 이벤트 핸들러를 연결합니다.
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
            this.Load += RegisterForm_Load;

            // --- 각종 컨트롤 이벤트 핸들러 연결 ---
            txtUsername.TextChanged += TxtUsername_TextChanged;
            btnCheckUsername.Click += BtnCheckUsername_Click;
            txtPasswordConfirm.TextChanged += TxtPasswordConfirm_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            btnSendVerification.Click += BtnSendVerification_Click;
            btnConfirmVerification.Click += BtnConfirmVerification_Click;
            txtNickname.TextChanged += TxtNickname_TextChanged;
            btnCheckNickname.Click += BtnCheckNickname_Click;
            btnUploadImage.Click += BtnUploadImage_Click;
            btnBack.Click += BtnBack_Click;
            btnCancel.Click += BtnCancel_Click;
            btnNextOrRegister.Click += BtnNextOrRegister_Click;
        }

        

        /// <summary>
        /// 폼이 처음 로드될 때 호출됩니다.
        /// </summary>
        private void RegisterForm_Load(object? sender, EventArgs e)
        {
            FirstForm_Load();
        }

        #region ===== Panel Register (1단계) =====

        // 아이디 입력값이 변경될 때마다 중복 확인 상태를 초기화합니다.
        private void TxtUsername_TextChanged(object? sender, EventArgs e)
        {
            isUsernameChecked = false;
            lblUsernameStatus.Visible = true;
            lblUsernameStatus.Text = "아이디 중복 확인을 해주세요.";
            lblUsernameStatus.ForeColor = Color.Red;
        }

        // '아이디 중복 확인' 버튼 클릭 시 아이디 유효성 및 중복 여부를 검사합니다.
        private void BtnCheckUsername_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (username.Length < 4 || username.Length > 15)
            {
                MessageBox.Show("아이디는 4자 이상, 15자 이하로 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UserDbHandler.IsUsernameExists(username))
            {
                lblUsernameStatus.Text = "이미 사용 중인 아이디입니다.";
                lblUsernameStatus.ForeColor = Color.Red;
                isUsernameChecked = false;
            }
            else
            {
                lblUsernameStatus.Text = "사용 가능한 아이디입니다.";
                lblUsernameStatus.ForeColor = Color.Green;
                isUsernameChecked = true;
            }
        }

        // 비밀번호 입력란에 값이 변할때 마다 비밀번호 유효성 검사를 수행합니다.
        private void TxtPassword_TextChanged(object? sender, EventArgs e)
        {
            string password = txtPassword.Text;
            int score = 0;

            // 1. 길이 검사
            if (password.Length >= 6 && password.Length <= 20)
            {
                // 길이 조건 충족
            }

            // 2. 포함된 문자 종류 검사
            int charTypeCount = 0;
            if (Regex.IsMatch(password, "[a-z]")) charTypeCount++; // 영문 소문자
            if (Regex.IsMatch(password, "[A-Z]")) charTypeCount++; // 영문 대문자
            if (Regex.IsMatch(password, "[0-9]")) charTypeCount++; // 숫자
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) charTypeCount++; // 특수문자

            // 3. 점수 계산
            if (password.Length >= 6) score++;
            if (password.Length >= 10) score++;
            if (charTypeCount >= 2) score++;
            if (charTypeCount >= 3) score++;
            if (charTypeCount >= 4) score++;

            // 4. 강도 및 색상 표시
            if (password.Length == 0)
            {
                lblPasswordStrength.Text = "";
            }
            else if (score <= 2)
            {
                lblPasswordStrength.Text = "약함";
                lblPasswordStrength.ForeColor = Color.Red;
            }
            else if (score <= 4)
            {
                lblPasswordStrength.Text = "중간";
                lblPasswordStrength.ForeColor = Color.Orange;
            }
            else
            {
                lblPasswordStrength.Text = "강함";
                lblPasswordStrength.ForeColor = Color.Green;
            }
        }

        // '비밀번호 표시' 체크박스 상태에 따라 비밀번호 입력란의 표시 방식을 변경합니다.
        private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            txtPasswordConfirm.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        // 비밀번호 확인 입력값이 변경될 때마다 일치 여부를 표시합니다.
        private void TxtPasswordConfirm_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                lblPasswordStatus.Text = "";
            }
            else if (txtPassword.Text == txtPasswordConfirm.Text)
            {
                lblPasswordStatus.Text = "비밀번호가 일치합니다.";
                lblPasswordStatus.ForeColor = Color.Green;
            }
            else
            {
                lblPasswordStatus.Text = "비밀번호가 일치하지 않습니다.";
                lblPasswordStatus.ForeColor = Color.Red;
            }
        }

        // '인증 메일 발송' 버튼 클릭 시(아직 미구현)
        private void BtnSendVerification_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // '인증 확인' 버튼 클릭 시(아직 미구현)
        private void BtnConfirmVerification_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("이 기능은 아직 구현되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEmailVerified = true;
        }

        #endregion

        #region ===== UserProfile (2단계) ===== 

        // 닉네임 입력값이 변경될 때마다 중복 확인 상태를 초기화합니다.
        private void TxtNickname_TextChanged(object? sender, EventArgs e)
        {
            isNicknameChecked = false;
            lblNicknameStatus.Text = "닉네임 중복 확인을 해주세요.";
            lblNicknameStatus.ForeColor = Color.Red;
        }

        // '닉네임 중복 확인' 버튼 클릭 시 닉네임 유효성 및 중복 여부를 검사합니다.
        private void BtnCheckNickname_Click(object? sender, EventArgs e)
        {
            string nickname = txtNickname.Text.Trim();
            if (string.IsNullOrEmpty(nickname))
            {
                MessageBox.Show("닉네임을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UserDbHandler. IsNicknameExists(nickname))
            {
                lblNicknameStatus.Text = "이미 사용 중인 닉네임입니다.";
                lblNicknameStatus.ForeColor = Color.Red;
                isNicknameChecked = false;
            }
            else
            {
                lblNicknameStatus.Text = "사용 가능한 닉네임입니다.";
                lblNicknameStatus.ForeColor = Color.Green;
                isNicknameChecked = true;
            }
        }

        // '이미지 업로드' 버튼 클릭 시 프로필 이미지를 선택하고 용량을 검사합니다.
        private void BtnUploadImage_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    if (fileInfo.Length > 2 * 1024 * 1024)
                    {
                        MessageBox.Show("이미지 파일은 2MB를 초과할 수 없습니다.", "용량 초과", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    profileImagePath = ofd.FileName;
                    picProfileImage.Image = Image.FromFile(profileImagePath);
                    lblImageStatus.Text = "이미지가 선택되었습니다.";
                    lblImageStatus.ForeColor = Color.Green;
                }
            }
        }

        #endregion

        #region ===== Panel Buttons (공통 버튼) =====

        // '다음' 또는 '가입 완료' 버튼 클릭 시 단계별로 입력값을 검증하고 회원가입을 처리합니다.
        private async void BtnNextOrRegister_Click(object? sender, EventArgs e)
        {
            if (pnlStep1.Visible)
            {
                // 비밀번호 정책 유효성 검사
                if (!IsValidPassword(txtPassword.Text))
                {
                    MessageBox.Show("비밀번호는 6~20자이며, 영문/숫자/특수문자 중 2가지 이상을 조합해야 합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 1단계: 아이디, 비밀번호, 약관 동의 등 입력값 검증
                if (!isUsernameChecked || txtPassword.Text != txtPasswordConfirm.Text || !chkAgreeToTerms.Checked || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("입력 정보를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ShowStep2();
            }
            else
            {
                // 2단계: 닉네임 중복 확인 및 이미지 업로드 처리
                if (!isNicknameChecked)
                {
                    MessageBox.Show("닉네임 중복 확인을 해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                panelButtons.Enabled = false;
                string imageUrl = null;
                if (!string.IsNullOrEmpty(profileImagePath))
                {
                    lblImageStatus.Text = "이미지 업로드 중...";
                    imageUrl = await BlobStorageManager.Instance.UploadProfileImageAsync(profileImagePath);
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        MessageBox.Show("이미지 업로드에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        panelButtons.Enabled = true;
                        return;
                    }
                }

                // 회원가입 요청
                bool success = UserDbHandler.RegisterUser(txtUsername.Text, txtPassword.Text, txtNickname.Text, txtEmail.Text, imageUrl);
                panelButtons.Enabled = true;

                if (success)
                {
                    RegisterSuccess?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("회원가입 중 오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // '취소' 버튼 클릭 시 회원가입을 중단할지 확인 후 폼을 닫습니다.
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("회원가입을 중단하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // '뒤로' 버튼 클릭 시 1단계로 돌아갑니다.
        private void BtnBack_Click(object? sender, EventArgs e)
        {
            ShowStep1();
        }

        #endregion

        #region ===== UI 상태 관리 메서드 =====

        // 1단계(아이디/비밀번호) UI를 보여줍니다.
        private void ShowStep1()
        {
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            btnBack.Enabled = false;
            btnNextOrRegister.Text = "다음";
            this.AcceptButton = btnNextOrRegister;
            lblUsernameStatus.Visible = false;
            lblPasswordStatus.Visible = false;
            ObjectLocation_Set();
        }

        // 2단계(프로필/닉네임) UI를 보여줍니다.
        private void ShowStep2()
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            btnBack.Enabled = true;
            btnNextOrRegister.Text = "가입 완료";
            this.AcceptButton = btnNextOrRegister;
            ObjectLocation_Set();
        }

        // 폼이 처음 로드될 때 1단계 UI를 보여줍니다.
        private void FirstForm_Load()
        {
            ShowStep1();
        }

        // 각 컨트롤의 위치를 UIHelper를 이용해 배치합니다.
        private void ObjectLocation_Set()
        {
            UIHelper.CenterHorizontally(this, lblStep1Title);
            UIHelper.AlignToTop(this, lblStep1Title, 20);
            UIHelper.CenterHorizontally(this, lblStep2Title);
            UIHelper.AlignToTop(this, lblStep2Title, 20);

            UIHelper.AlignToTopLeft(panelButtons, btnBack, 20);
            UIHelper.AlignToTopRight(panelButtons, btnNextOrRegister, 20);
            UIHelper.CenterHorizontally(panelButtons, btnCancel);
            UIHelper.AlignToBottom(panelButtons, btnCancel, 20);
        }

        #endregion

        /// <summary>
        /// 비밀번호가 설정된 정책(길이, 문자 종류)을 충족하는지 검사합니다.
        /// </summary>
        /// <param name="password">검사할 비밀번호 문자열</param>
        /// <returns>유효하면 true, 그렇지 않으면 false</returns>
        private bool IsValidPassword(string password)
        {
            // 1. 길이 검사 (6~20자)
            if (password.Length < 6 || password.Length > 20)
            {
                return false;
            }

            // 2. 포함된 문자 종류가 2가지 이상인지 검사
            int charTypeCount = 0;
            if (Regex.IsMatch(password, "[a-z]")) charTypeCount++; // 영문 소문자
            if (Regex.IsMatch(password, "[A-Z]")) charTypeCount++; // 영문 대문자
            if (Regex.IsMatch(password, "[0-9]")) charTypeCount++; // 숫자
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) charTypeCount++; // 특수문자

            return charTypeCount >= 2;
        }
    }
}

