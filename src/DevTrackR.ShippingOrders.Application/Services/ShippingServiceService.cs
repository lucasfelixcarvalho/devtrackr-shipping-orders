﻿using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Repositories;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingServiceService : IShippingServiceService
    {
        private readonly IShippingServiceRepository _repository;

        public ShippingServiceService(IShippingServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = await _repository.GetAllAsync();

            return shippingServices.Select(s => ShippingServiceViewModel.FromEntity(s)).ToList();
        }
    }
}
