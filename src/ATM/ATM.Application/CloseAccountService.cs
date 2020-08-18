//using System;
//using System.Threading.Tasks;
//using ATM.Application.Repository;
//using AutoMapper;
//using CSESoftware.Repository.Builder;

//namespace ATM.Application
//{
//	public class CloseAccountService
//	{
//		private readonly IAtmRepository _repository;
//		private readonly IMapper _mapper;

//		public CloseAccountService(IAtmRepository repository, IMapper mapper)
//		{
//			_repository = repository;
//			_mapper = mapper;
//		}


//		//public async Task CloseAccount(int holderId, Guid accountId)
//		//{
//		//	var savedAccount = await _repository.GetFirstAsync(
//		//		new QueryBuilder<Persistence.Models.Account>()
//		//			.Where(x => x.HolderId == holderId
//		//					&& x.Id == accountId
//		//					&& x.IsActive)
//		//			.Build());

//		//	if (savedAccount == null)
//		//		throw new Exception("Account does not exist for this holder");

//		//	var account = _mapper.Map<Persistence.Models.Account, Account>(savedAccount);

//		//	if (Math.Abs(account.Balance) > 0.001)
//		//		throw new Exception("Account balance is not $0.00");

//		//	savedAccount.IsActive = false;
//		//} //todo this should be on Account
//	}
//}
