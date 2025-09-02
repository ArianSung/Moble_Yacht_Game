// 이 네임스페이스에 있는 클래스들을 '사용'하겠다는 선언입니다.
using Moble_Yacht_Game.Database.Core;
using Moble_Yacht_Game.Database.DataModels;
using Moble_Yacht_Game.UserControls;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game
{
    /// <summary>
    /// 이 프로그램의 메인 창(Form)입니다.
    /// SPA(Single Page Application) 패턴에서 이 폼은 전체적인 '껍데기' 역할을 하며,
    /// 내부에 있는 mainPanel 위에 UserControl(화면)들을 교체하며 보여주는 방식으로 동작합니다.
    /// </summary>
    public partial class MainForm : Form
    {
        // --- 화면(UserControl) 인스턴스 변수 선언 ---
        private LoginControl loginControl;

        public MainForm()
        {
            // 디자이너에서 만든 UI 요소들을 초기화하는 필수 메서드입니다.
            InitializeComponent();

            // 폼의 Load 이벤트와 FormClosing 이벤트를 각각의 메서드와 연결합니다.
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// MainForm이 처음 로드될 때 단 한 번 실행되는 메서드입니다.
        /// 이 곳에서 각종 초기화 작업을 수행합니다.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // --- 1. 데이터베이스 연결 시도 ---
            try
            {
                // 프로그램이 시작되면 가장 먼저 데이터베이스에 연결을 시도합니다.
                DatabaseManager.Instance.Connect();
            }
            catch (Exception ex)
            {
                // DatabaseManager에서 연결 실패 시 던진(throw) 예외(Exception)를 여기서 잡습니다.
                // UI와 관련된 처리는 이처럼 UI 계층에서 책임지는 것이 좋은 구조입니다.
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // 연결에 실패했으므로 프로그램을 종료합니다.
                return; // 예외 발생 시 더 이상 진행하지 않도록 메서드를 종료합니다.
            }

            // --- 2. 컨트롤 초기화 및 시작 화면 표시 ---
            // 데이터베이스 연결에 성공한 경우에만 컨트롤들을 초기화하고 화면을 보여줍니다.
            InitializeControls();
            ShowControl(loginControl);
        }

        /// <summary>
        /// 사용자가 창의 닫기(X) 버튼을 누르는 등 폼이 닫히기 직전에 실행되는 이벤트 핸들러입니다.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 프로그램이 종료되기 전에 데이터베이스 연결을 안전하게 닫아줍니다.
            DatabaseManager.Instance.Disconnect();
        }

        /// <summary>
        /// 화면(UserControl)들을 생성하고 이벤트를 연결하는 초기화 작업을 담당합니다.
        /// </summary>
        private void InitializeControls()
        {
            loginControl = new LoginControl();
            loginControl.LoginSuccess += OnLoginSuccess;
            // RegisterControl은 별도의 Form으로 분리했으므로, MainForm이 더 이상 알 필요가 없습니다.
        }

        /// <summary>
        /// 지정된 UserControl을 메인 패널에 표시하는 범용 메서드입니다.
        /// </summary>
        private void ShowControl(UserControl controlToShow)
        {
            mainPanel.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(controlToShow);
        }

        /// <summary>
        /// LoginControl에서 로그인 성공 이벤트가 발생했을 때 호출되는 메서드입니다.
        /// </summary>
        private void OnLoginSuccess(UserData userData)
        {
            MessageBox.Show($"{userData.Nickname}님, 환영합니다!");
            // TODO: (향후 구현) 이 곳에서 로비 화면(LobbyControl)으로 전환하는 코드를 작성합니다.
            // 예: ShowControl(lobbyControl);
        }
    }
}

