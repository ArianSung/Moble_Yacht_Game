using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Moble_Yacht_Game.Managers
{
    /// <summary>
    /// Azure Blob Storage와의 통신(파일 업로드 등)을 관리하는 싱글톤 클래스입니다.
    /// </summary>
    public class BlobStorageManager
    {
        // --- 싱글톤 패턴 구현 ---
        private static BlobStorageManager _instance;
        public static BlobStorageManager Instance => _instance ??= new BlobStorageManager();
        // --- 싱글톤 패턴 구현 끝 ---

        private readonly BlobServiceClient blobServiceClient;

        /// <summary>
        /// 생성자에서 appsettings.json 파일로부터 Azure Blob Storage 연결 문자열을 불러와 클라이언트를 초기화합니다.
        /// </summary>
        private BlobStorageManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("AzureBlobStorage");

            // 연결 문자열이 없는 경우를 대비한 예외 처리
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("appsettings.json 파일에서 AzureBlobStorage 연결 문자열을 찾을 수 없습니다.");
            }

            blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <summary>
        /// 지정된 로컬 파일 경로의 이미지를 'profiles' 컨테이너에 업로드합니다.
        /// </summary>
        /// <param name="localFilePath">사용자가 선택한 이미지의 PC 내 전체 경로</param>
        /// <returns>업로드 성공 시, 이미지에 접근할 수 있는 공용 URL을 반환합니다. 실패 시 null을 반환합니다.</returns>
        public async Task<string> UploadProfileImageAsync(string localFilePath)
        {
            try
            {
                // 'profiles' 라는 이름의 컨테이너 클라이언트를 가져옵니다. (컨테이너는 미리 생성되어 있어야 합니다.)
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("profiles");

                // 파일 확장자를 유지하면서, 전 세계에서 유일한 파일 이름을 생성합니다. (예: guid.png)
                // 이렇게 해야 다른 사용자가 같은 이름의 파일을 올려도 덮어쓰지 않습니다.
                string uniqueBlobName = $"{Guid.NewGuid()}{Path.GetExtension(localFilePath)}";

                // 컨테이너 내에서 참조할 Blob(파일) 클라이언트를 가져옵니다.
                BlobClient blobClient = containerClient.GetBlobClient(uniqueBlobName);

                // 지정된 로컬 파일 경로에서 파일을 읽어 Azure에 비동기적으로 업로드합니다.
                await blobClient.UploadAsync(localFilePath, true);

                // 업로드된 파일의 공용 URL을 반환합니다.
                return blobClient.Uri.ToString();
            }
            catch (Exception)
            {
                // 업로드 중 오류가 발생하면 null을 반환하여 실패를 알립니다.
                return null;
            }
        }
    }
}

