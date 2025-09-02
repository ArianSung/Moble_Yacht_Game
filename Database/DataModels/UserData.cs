namespace Moble_Yacht_Game.Database.DataModels
{
    /// <summary>
    /// 데이터베이스의 'Users' 테이블에서 조회한 데이터를 프로그램 내에서 사용하기 편한 형태로 담아두는 클래스입니다.
    /// 이런 목적의 클래스를 DTO(Data Transfer Object, 데이터 전송 객체)라고도 부릅니다.
    /// </summary>
    public class UserData
    {
        // DB의 user_id 컬럼에 해당하는 값
        public long UserId { get; set; }

        // DB의 nickname 컬럼에 해당하는 값
        public string Nickname { get; set; }

        // DB의 rank_score 컬럼에 해당하는 값
        public int RankScore { get; set; }

        // DB의 wins 컬럼에 해당하는 값
        public int Wins { get; set; }

        // DB의 losses 컬럼에 해당하는 값
        public int Losses { get; set; }

        // 여기에 나중에 필요한 유저 데이터(예: 보유 재화, 레벨 등)를 계속 추가할 수 있습니다.
    }
}

