using BusinessLogicLayer.DTOs.AboutDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AboutServices
{
    public interface IAboutService
    {
        Task<AboutDTO> GetAboutContent();

        Task StoreAboutContent(string content);
    }
}
