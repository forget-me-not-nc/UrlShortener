using BusinessLogicLayer.Config.About;
using BusinessLogicLayer.DTOs.AboutDTOs;

namespace BusinessLogicLayer.Services.AboutServices.Impls
{
    public class AboutService : IAboutService
    {
        public async Task<AboutDTO> GetAboutContent()
        {
            AboutDTO aboutDTO = new();

            try
            {
                if (!File.Exists(AboutConfig.FILE_NAME))
                {
                    File.WriteAllText(AboutConfig.FILE_NAME, string.Empty);
                }

                aboutDTO.Content = await File.ReadAllTextAsync(AboutConfig.FILE_NAME);

                return aboutDTO;
            }
            catch (Exception) { throw; }
            
        }

        public async Task StoreAboutContent(string content)
        {
            try
            {
                await File.WriteAllTextAsync(AboutConfig.FILE_NAME, content);
            }
            catch (Exception) { throw; }
        }
    }
}
