using System.Windows.Forms;

// 이 네임스페이스는 프로젝트 전반에서 사용할 수 있는 유용한 도우미 기능들을 담습니다.
namespace Moble_Yacht_Game.Helpers
{
    /// <summary>
    /// UI 컨트롤과 관련된 반복적인 작업을 도와주는 정적 클래스입니다.
    /// (예: 컨트롤을 부모의 특정 위치에 배치하기 등)
    /// </summary>
    public static class UIHelper
    {
        #region === Center Alignment ===

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 가로(수평) 중앙에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤 (예: this, a Panel, a Form)</param>
        /// <param name="childToCenter">중앙에 배치할 자식 컨트롤</param>
        public static void CenterHorizontally(Control parentControl, Control childToCenter)
        {
            childToCenter.Left = (parentControl.ClientSize.Width - childToCenter.Width) / 2;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 세로(수직) 중앙에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤</param>
        /// <param name="childToCenter">중앙에 배치할 자식 컨트롤</param>
        public static void CenterVertically(Control parentControl, Control childToCenter)
        {
            childToCenter.Top = (parentControl.ClientSize.Height - childToCenter.Height) / 2;
        }

        #endregion

        #region === Side Alignment ===

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 왼쪽에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤</param>
        /// <param name="childToAlign">정렬할 자식 컨트롤</param>
        /// <param name="margin">왼쪽 여백 (기본값 0)</param>
        public static void AlignToLeft(Control parentControl, Control childToAlign, int margin = 0)
        {
            childToAlign.Left = margin;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 오른쪽에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤</param>
        /// <param name="childToAlign">정렬할 자식 컨트롤</param>
        /// <param name="margin">오른쪽 여백 (기본값 0)</param>
        public static void AlignToRight(Control parentControl, Control childToAlign, int margin = 0)
        {
            childToAlign.Left = parentControl.ClientSize.Width - childToAlign.Width - margin;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 위쪽에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤</param>
        /// <param name="childToAlign">정렬할 자식 컨트롤</param>
        /// <param name="margin">위쪽 여백 (기본값 0)</param>
        public static void AlignToTop(Control parentControl, Control childToAlign, int margin = 0)
        {
            childToAlign.Top = margin;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 아래쪽에 배치합니다.
        /// </summary>
        /// <param name="parentControl">기준이 되는 부모 컨트롤</param>
        /// <param name="childToAlign">정렬할 자식 컨트롤</param>
        /// <param name="margin">아래쪽 여백 (기본값 0)</param>
        public static void AlignToBottom(Control parentControl, Control childToAlign, int margin = 0)
        {
            childToAlign.Top = parentControl.ClientSize.Height - childToAlign.Height - margin;
        }

        #endregion

        #region === Corner Alignment ===

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 왼쪽 상단 모서리에 배치합니다.
        /// </summary>
        public static void AlignToTopLeft(Control parentControl, Control childToAlign, int marginX = 0, int marginY = 0)
        {
            childToAlign.Left = marginX;
            childToAlign.Top = marginY;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 오른쪽 상단 모서리에 배치합니다.
        /// </summary>
        public static void AlignToTopRight(Control parentControl, Control childToAlign, int marginX = 0, int marginY = 0)
        {
            childToAlign.Left = parentControl.ClientSize.Width - childToAlign.Width - marginX;
            childToAlign.Top = marginY;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 왼쪽 하단 모서리에 배치합니다.
        /// </summary>
        public static void AlignToBottomLeft(Control parentControl, Control childToAlign, int marginX = 0, int marginY = 0)
        {
            childToAlign.Left = marginX;
            childToAlign.Top = parentControl.ClientSize.Height - childToAlign.Height - marginY;
        }

        /// <summary>
        /// 지정된 자식 컨트롤을 부모 컨트롤의 오른쪽 하단 모서리에 배치합니다.
        /// </summary>
        public static void AlignToBottomRight(Control parentControl, Control childToAlign, int marginX = 0, int marginY = 0)
        {
            childToAlign.Left = parentControl.ClientSize.Width - childToAlign.Width - marginX;
            childToAlign.Top = parentControl.ClientSize.Height - childToAlign.Height - marginY;
        }

        #endregion
    }
}

