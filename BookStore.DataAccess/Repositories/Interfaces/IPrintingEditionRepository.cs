using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository
    {
        Task PrintingEditionsAsync(PrintingEditionsFilterModels printingEditionsFilterModels);
    }
}
