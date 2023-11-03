using Domain.Models;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Domain.Infrastructure;


namespace ServiceLayer
{
    public class EmployeeServiceLayer : IEmployeeServiceLayer
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeServiceLayer(IEmployeeRepo iemployee, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepo = iemployee;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<EmployeeDetail> AddEmployeeAsync(EmployeeDetail edt, IFormFile Files)
        {
            if (Files != null)
            {
                try
                {
                    string FileName = "NewFolder\\DataFile\\" + Files.FileName;
                    var _GetFilePath = Path.Combine(_webHostEnvironment.WebRootPath, FileName);
                    using var fileStream = new FileStream(_GetFilePath, FileMode.Create);
                    await Files.CopyToAsync(fileStream);

                    edt.FileUrl = FileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            edt.CreateBy = Guid.NewGuid();
            edt.CreatedOn = DateTime.Now;

            await _employeeRepo.Insert(edt).ConfigureAwait(false);
            _unitOfWork.CommitChanges();
            return edt;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id > 0)
            {
                var data = await _employeeRepo.GetByIdAsync(id);
                data.DeletedBy = Guid.NewGuid();
                data.DeletedOn = DateTime.Now;
                if (data != null)
                {
                    _employeeRepo.Delete(data);
                    var result = _unitOfWork.CommitChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            return false;

        }

        public Task<bool> EditEmployeeAsync(EmployeeDetail edt)
        {

            // get by id
            //value assign
            //update
            edt.ModifiedBy = Guid.NewGuid();
            edt.ModifiedOn = DateTime.Now;
            _employeeRepo.Update(edt);
            _unitOfWork.CommitChanges();
            return Task.FromResult(true);
        }

        public async Task<EmployeeDetail> GetEmployeeByIdAsync(int id)
        {
            var result = await _employeeRepo.GetByIdAsync(id).ConfigureAwait(false);
            return result;
        }

        public async Task<GetAllSP> DetailByIdAsync(int id)
        {
            var res = await _employeeRepo.GetAllEmployeeFromProceAsync(id);
            return res.First();
        }

        public async Task<List<GetAllSP>> GetEmployeeDetailAsync()
        {

            var data = await _employeeRepo.GetAllEmployeeFromProceAsync(0).ConfigureAwait(false);
            return data.ToList();
        }
        public async Task<List<EmployeeDetail>> GetEmployees()
        {
            var data = await _employeeRepo.GetAllAsync().ConfigureAwait(false);
            return data.ToList();
        }
        public async Task<string> UploadFiles(IFormFile Files)
        {

            try
            {
                string FileName = "";

                var _GetFilePath = Path.Combine(_webHostEnvironment.WebRootPath, FileName);
                using (var fileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await Files.CopyToAsync(fileStream);
                }
                return FileName;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
