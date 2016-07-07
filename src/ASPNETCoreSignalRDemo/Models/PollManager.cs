using System;
using System.Collections.Generic;
using System.Linq;
using ASPNETCoreSignalRDemo.Models.DB;
using ASPNETCoreSignalRDemo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreSignalRDemo.Models
{
    public class PollManager : IPollManager
    {
        private readonly ASPNETCoreDemoDBContext _db;
        public PollManager(ASPNETCoreDemoDBContext context)
        {
            _db = context;
        }
        public IEnumerable<PollDetailsViewModel> GetActivePoll()
        {
            if (_db.Poll.Any())
                return _db.Poll.Include(o => o.PollOption).Where(o => o.Active == true)
                    .Select(o => new PollDetailsViewModel {
                        PollID = o.PollId,
                        Question = o.Question,
                        PollOption = o.PollOption
                    });

            return Enumerable.Empty<PollDetailsViewModel>();
        }
        public bool AddPoll(AddPollViewModel pollModel)
        {
           
            using (var dbContextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var answers = pollModel.Answer.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    Poll poll = new Poll();
                    poll.Question = pollModel.Question;
                    poll.Active = true;
                    _db.Poll.Add(poll);
                    _db.SaveChanges();

                    foreach (var answer in answers)
                    {
                        PollOption option = new PollOption();
                        option.PollId = poll.PollId;
                        option.Answers = answer;
                        option.Vote = 0;
                        _db.PollOption.Add(option);
                        _db.SaveChanges();
                    }

                    dbContextTransaction.Commit();

                }
                catch
                {
                    //TO DO: log error here
                    dbContextTransaction.Rollback();
                }
            }

            return true;
        }
    }
}
