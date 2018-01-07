using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Picture;
using OrgMan.DomainObjects.Picture;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Picture
{
    public class InsertPictureQueryHandler : QueryHandlerBase
    {
        private InsertPictureQuery _query;

        public InsertPictureQueryHandler(InsertPictureQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public PictureDomainModel Handle()
        {
            try
            {
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                var individualPerson = uow.IndividualPersonRepository.Get(_query.Picture.IndividualPersonUID);

                if (individualPerson != null)
                {
                    throw new DataException("No Entity found to UID : " + _query.Picture.IndividualPersonUID);
                }

                string combinedPath = Path.Combine(_query.PictureDirectoryPath, individualPerson.PictureLink);

                if (!Directory.Exists(combinedPath))
                {
                    throw new FileNotFoundException(string.Format("File {0} does not Exists", combinedPath));
                }
                else
                {
                    System.IO.File.WriteAllBytes(combinedPath, _query.Picture.Picture);

                    individualPerson.PictureLink = combinedPath;

                    uow.IndividualPersonRepository.Update(individualPerson);

                    return _query.Picture;
                }
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
