namespace Moble_Yacht_Game.Database.DataModels
{
    /// <summary>
    /// 사용자 정보를 담는 데이터 모델 클래스입니다.
    /// 데이터베이스에서 유저 정보를 읽어오거나 전달할 때 사용합니다.
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// 사용자 고유 ID (DB의 user_id 컬럼과 매칭)
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 사용자의 닉네임 (DB의 nickname 컬럼과 매칭)
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 사용자의 랭크 점수 (DB의 rank_score 컬럼과 매칭)
        /// </summary>
        public int RankScore { get; set; }

        /// <summary>
        /// 사용자의 승리 횟수 (DB의 wins 컬럼과 매칭)
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// 사용자의 패배 횟수 (DB의 losses 컬럼과 매칭)
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// 프로필 이미지의 URL (DB의 profile_image_url 컬럼과 매칭, 없을 수 있음)
        /// </summary>
        public string? ProfileImageUrl { get; set; }
    }
}

