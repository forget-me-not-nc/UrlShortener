export class ApiConfig {
  private static readonly API_ROUTE: string = 'http://localhost:5185/';
  public static readonly URL_API: string = ApiConfig.API_ROUTE + 'api/url/';
  public static readonly AUTH_API: string = ApiConfig.API_ROUTE + 'api/auth/';
  public static readonly REDIRECT_API: string = ApiConfig.API_ROUTE + 'api/redirect/';
}
