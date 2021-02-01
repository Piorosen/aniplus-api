# 애니플러스 API
> [aniplustv](https://www.aniplustv.com/) 사이트에서 제공하는 검색, 정보를 API 형식으로 제공 합니다.<br>
> 단독으로 사용이 불가능 하며, 라이브러리 형식으로 제공이 됩니다. 라이브러리를 이용하여 프로그램을 개발 하시면 됩니다.<br>
> 테스트를 위한 테스트 프로젝트는 [CUI 버전](https://github.com/Piorosen/aniplus-api/tree/main/TestCuiAniplus) 이고, [UnitTest 버전](https://github.com/Piorosen/aniplus-api/tree/main/TestAniplusApi) 형식으로 제공이 되고 있습니다.<br>
> 바로 사용이 필요하시다면 TestCuiAniplus 를 빌드 하셔서 사용하시면 됩니다.<br>
> 개발 일자는 2021년 2월 1일에 마감을 하였으며, 변경 사안및 수정은 Issue에 등록해 주세요.<br>

## Dependencies
- .Net Core 3.1

## Installation
```bash
$> git clone https://github.com/Piorosen/aniplus-api.git
$> dotnet add $(target project) reference $(aniplus-api) # [More Detail](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-add-reference)
```

## Usage
### 1. Raw Api
```cs
// Query 기준으로 애니를 검색 합니다.
Aniplus_Api.AniPlusApi.Search(string query, int page = 1, string userId = "")

// 검색한 애니를 기준으로 애내메이션 정보를 검색 합니다.
Aniplus_Api.AniPlusApi.GetAnimeInformation(int contentSerial)

// 검색한 애니를 기준으로 애니메이션의 영상의 정보를 가지고 옵니다.
Aniplus_Api.AniPlusApi.GetVideoInformation(int contentSerial, string userId = "")

// 검색한 애니를 기준으로 등장 인물 정보를 가지고 옵니다.
Aniplus_Api.AniPlusApi.GetCharactersInformation(int contentSerial, string userId = "")

// 검색한 애니를 기준으로 애니메이션 미리보기 사진의 다운로드 경로를  가지고 옵니다.
Aniplus_Api.AniPlusApi.GetStillCutImage(int contentSerial, string userId = "")

// 검색한 애니를 기준으로 성별 추천 정보를 가지고 옵니다.
Aniplus_Api.AniPlusApi.GetSexRateInformation(int contentSerial)

// 검색한 애니를 기준으로 나이별 추천 정보를 가지고 옵니다.
Aniplus_Api.AniPlusApi.GetAgeRateInformation(int contentSerial)

// 검색한 애니를 기준으로 별점당 몇명이 했는지 접오를 가지고 옵니다.
Aniplus_Api.AniPlusApi.GetStarRateInformation(int contentSerial)
```

### 2. Wrapped Api (more easily)
  - 애니메이션 검색 및 고유 번호로 검색 기능
```cs
// Query 기준으로 애니를 검색 합니다.
Aniplus_Api.AniplusSeach.Search(string query, int page = 1, string userId = "")

// GetAnimeInformation 함수를 이용해서 애니메이션 정보를 가지고 옵니다.
// 일부가 다르게 결과가 나올 수 있습니다. (애니메이션의 썸네일 다운로드 경로가 다릅니다.)
Aniplus_Api.AniplusSeach.Search(int contentSeiral)
```
<br>

  - 검색 후, 나온 결과를 바탕으로 애니메이션 정보 가지고 오는 기능

```cs 
// AniplusSearch.Search를 이용해서 나온 반환 값은 Anime 입니다.
// Anime 밑에 Property로 Video, Character,Ratio, StillCuts, MoreInfo 정보가 있습니다.
// 각 기능은 생성자에서 즉시 계산이 되는것이 아닌, 지연 평가(lazy evaluation)를 합니다. 사용 및 접근 할 때만 동작합니다.

// 비디오 정보를 가지고 옵니다. AniPlusApi에서 GetVideoInformation를 이용합니다.
anime.Videos

// GetCharactersInformation함수를 이용하여 결과를 계산합니다.
anime.Characters

// GetSexRateInformation, GetAgeRateInformation, GetStarRateInformation 함수를 이용하여 결과를 반환합니다.
anime.Ratio

// GetStillCutImage함수를 이용하여 결과를 계산합니다.
anime.StillCuts

// GetAnimeInformation함수를 이용하여 계산합니다.
anime.MoreInfo

// 최초 검색시 나오는 AniplusApi에서 Search한 결과를 저장합니다. (GetAnimeInformation 결과는 썸네일 부분에서 다릅니다.)
anime.Info
```

## [Sample](https://github.com/Piorosen/aniplus-api/blob/main/TestAniplusApi/UnitTest1.cs#L134)
  - Wrapped 된 API를 이용하여 개발한하는 방법에 대하여 기술 함.
