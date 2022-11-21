using AutoMapper;
using Capaci.BLL.interfaces;
using Capaci.DAL.interfaces;
using Capaci.DTO.Models;
using Capaci.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.BLL
{
    public  class SubscriptionService : ISubscriptionService
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _repository;
        private readonly IAdminProductRepository _adminProductRepository;
        public SubscriptionService(ISubscriptionRepository repository, IMapper mapper, IAdminProductRepository adminProductRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _adminProductRepository = adminProductRepository;
        }

        public async Task<bool> Create(SubscriptionViewModel viewModel)
        {

            try
            {
                var model = new Subscription();
                // _mapper.Map(viewModel, model);
                model.SubscriberName = viewModel.SubscriberName;
                model.ProductId = viewModel.ProductId;
                model.PhoneNumber = viewModel.PhoneNumber;
                model.FullAddress=viewModel.FullAddress;  
                model.ProductName=viewModel.ProductName;
                model.UserId=viewModel.UserId;
               model.Price=viewModel.Price;

                await _repository.Create(model);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var listView = new List<SubscriptionViewModel>();
            var listModel = await _repository.GetAll();

            foreach (var item in listModel)
            {
                var viewModel = new SubscriptionViewModel();
                _mapper.Map(item, viewModel);
                listView.Add(viewModel);
            }

            return listView;
        }

        public async Task<SubscriptionViewModel> GetById(string Id)
        {
            try
            {
                var model = await _repository.GetById(Guid.Parse(Id));
                var viewModel = new SubscriptionViewModel();
                _mapper.Map(model, viewModel);

                return viewModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetByUserId(Guid UserId)
        {
            var products= await _adminProductRepository.GetAll();
            var productListbyUserId = new List<ProductViewModel>();
            var list = new List<SubscriptionViewModel>();
            var subscriptionmodel = await _repository.GetByUserId(UserId);
            foreach (var item in subscriptionmodel)
            {
                var prod = products.Where(w => w.Id == item.ProductId).FirstOrDefault();

                var viewmodel = new ProductViewModel() { ImagePath = prod.ImagePath, Name=prod.Name, Description=prod.Description  };
                productListbyUserId.Add(viewmodel);
            }






            return productListbyUserId;
        }
    }
}
