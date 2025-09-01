namespace Moble_Yacht_Game.Database.DataModels
{
    /// <summary>
    /// 로그인 성공 시, 클라이언트에서 사용할 사용자 정보를 담는 클래스입니다.
    /// </summary>
    public class UserData
    {
        public long UserId { get; set; }
        public string Nickname { get; set; }
        public int RankScore { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
