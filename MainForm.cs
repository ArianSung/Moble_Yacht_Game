// 이 네임스페이스에 있는 클래스들을 '사용'하겠다는 선언입니다.
using Moble_Yacht_Game.Database.Core;
using Moble_Yacht_Game.Database.DataModels; // UserData 클래스를 사용하기 위해
using Moble_Yacht_Game.UserControls;      // LoginControl, RegisterControl을 사용하기 위해
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

            // 폼이 처음 화면에 로드될 때 MainForm_Load 메서드를 실행하도록 이벤트를 구독(연결)합니다.
            this.Load += MainForm_Load;
        }

        /// <summary>
        /// MainForm이 처음 로드될 때 단 한 번 실행되는 메서드입니다.
        /// 이 곳에서 각종 초기화 작업을 수행합니다.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // --- 1. 화면(UserControl) 객체 생성 ---
            loginControl = new LoginControl();


            // --- 2. 이벤트 핸들러(처리기) 연결 ---

            loginControl.LoginSuccess += OnLoginSuccess;

            // --- 3. 시작 화면 표시 ---
            // --- 데이터베이스 연결 시도 ---
            // 프로그램이 시작되면 가장 먼저 데이터베이스에 연결을 시도합니다.
            if (DatabaseManager.Instance.Connect())
            {
                // 연결에 성공하면, 첫 화면으로 로그인 컨트롤을 보여줍니다.
                ShowControl(loginControl);
            }
            else
            {
                // 연결에 실패하면, 사용자에게 알리고 프로그램을 종료합니다.
                MessageBox.Show("데이터베이스에 연결할 수 없어 프로그램을 종료합니다.");
                Application.Exit();
            }
        }

        /// <summary>
        /// 사용자가 창의 닫기(X) 버튼을 누르는 등 폼이 닫히기 직전에 실행되는 이벤트 핸들러입니다.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // --- 데이터베이스 연결 해제 ---
            // 프로그램이 종료되기 전에 데이터베이스 연결을 안전하게 닫아줍니다.
            // 이렇게 해야 서버 자원 낭비를 막을 수 있습니다.
            DatabaseManager.Instance.Disconnect();
        }


        /// <summary>
        /// 지정된 UserControl을 메인 패널에 표시하는 범용 메서드입니다.
        /// 이 메서드 덕분에 화면 전환 코드가 중복되지 않고 간결해집니다.
        /// </summary>
        /// <param name="controlToShow">화면에 표시하고 싶은 UserControl의 인스턴스</param>
        private void ShowControl(UserControl controlToShow)
        {
            // 1. mainPanel에 이전에 표시되었을지도 모르는 컨트롤들을 모두 지웁니다.
            mainPanel.Controls.Clear();
            // 2. 파라미터로 받은 컨트롤의 Dock 속성을 Fill로 설정하여 mainPanel을 가득 채우도록 합니다.
            controlToShow.Dock = DockStyle.Fill;
            // 3. mainPanel의 자식 컨트롤로 추가하여 화면에 실제로 보이게 합니다.
            mainPanel.Controls.Add(controlToShow);
        }

        /// <summary>
        /// LoginControl에서 로그인 성공 이벤트가 발생했을 때 호출되는 메서드입니다.
        /// </summary>
        /// <param name="userData">로그인에 성공한 사용자의 정보가 담긴 객체</param>
        private void OnLoginSuccess(UserData userData)
        {
            // 로그인 성공을 환영하는 메시지 박스를 띄웁니다.
            MessageBox.Show($"{userData.Nickname}님, 환영합니다!");

            // (향후 구현) 이 곳에서 로비 화면으로 전환하는 코드가 실행될 것입니다.
            // 예: ShowControl(lobbyControl);
        }
    }
}

