using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        private EfCommentRepository efCommentRepository;

        public CommentManager(EfCommentRepository efCommentRepository)
        {
            this.efCommentRepository = efCommentRepository;
        }

        public CommentManager(NewsStyleUriParser newsStyleUriParser, ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x => x.BlogID == id);
        }

    }
}
