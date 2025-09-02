using Moble_Yacht_Game.Database.DataModels;
using Moble_Yacht_Game.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moble_Yacht_Game.UserControls
{
    public partial class LoginControl : UserControl
    {
        // --- 이벤트 선언 ---
        /// <summary>
        /// 로그인 성공 시 발생하는 이벤트입니다. 성공한 유저의 정보를 함께 전달합니다.
        /// </summary>
        public event Action<UserData> LoginSuccess;
        /// <summary>
        /// '회원가입' 버튼을 눌렀을 때 발생하는 이벤트입니다.
        /// </summary>
        public event Action RegisterRequested;
        // 아이디/비밀번호 찾기 기능은 나중에 구현할 것이므로, 우선 이벤트만 선언해 둡니다.
        // public event Action FindIdRequested;
        // public event Action FindPasswordRequested;

        public LoginControl()
        {
            InitializeComponent();

            // 이벤트 핸들러 연결
            this.Load += LoginControl_Load;
            this.Resize += LoginControl_Resize;

            btnLogin.Click += BtnLogin_Click;
            btnGoToRegister.Click += BtnGoToRegister_Click;
        }

        private void LoginControl_Load(object? sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void LoginControl_Resize(object? sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void BtnGoToRegister_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// UIHelper를 사용하여 컨트롤들의 위치를 조정합니다.
        /// </summary>
        private void UpdateControlPositions()
        {
            UIHelper.CenterHorizontally(this, picGameLogo);

            picGameLogo.Top = (this.ClientSize.Height / 2) - (picGameLogo.Height / 2) - 100;
            UIHelper.AlignToBottomRight(this, pnlLogin, 50,50);
        }
    }
}
