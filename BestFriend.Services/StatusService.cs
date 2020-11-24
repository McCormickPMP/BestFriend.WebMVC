using BestFriend.Data;
using BestFriend.Models.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Services
{
    public class StatusService
    {
        private readonly Guid _statusGuid;

        public StatusService(Guid statusGuid)
        {
            _statusGuid = statusGuid;
        }
        public bool CreateStatus(StatusCreate model)
        {
            var entity =
                new Status()
                {
                   
                    StatusId = model.StatusId,
                    StatusType = model.StatusType,
                    CreateStatus = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Statuses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StatusListItem> GetStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Statuses
                        .Where(e => e.StatusGuid == _statusGuid)
                        .Select(
                            e =>
                                new StatusListItem
                                {
                                    StatusId = e. StatusId,
                                    StatusType = e.StatusType,
                                    CreateStatus = DateTimeOffset.Now
                                }
                        );

                return query.ToArray();
            }
        }
        public StatusDetail GetStatusById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Statuses
                        .Single(e => e.StatusId == id && e.StatusGuid == _statusGuid);
                return
                    new StatusDetail
                    {
                        StatusId = entity.StatusId,
                        StatusType = entity.StatusType,
                        CreateStatus = DateTimeOffset.Now
                    };
            }
        }
        public bool UpdateStatus(StatusUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Statuses
                        .Single(e => e.StatusId == model.StatusId && e.StatusGuid == _statusGuid);

                entity.StatusId = model.StatusId;
                entity.StatusType = model.StatusType;
                entity.ModifyStatus = DateTimeOffset.Now;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStatus(int statusId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Statuses
                        .Single(e => e.StatusId == statusId && e.StatusGuid == _statusGuid);

                ctx.Statuses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

