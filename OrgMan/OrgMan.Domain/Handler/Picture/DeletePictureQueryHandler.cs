using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Picture;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.Domain.Handler.Picture
{
    public class DeletePictureQueryHandler : QueryHandlerBase
    {
        private DeletePictureQuery _query;

        public DeletePictureQueryHandler(DeletePictureQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public byte[] Handle()
        {
            try
            {
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                var individualPerson = uow.IndividualPersonRepository.Get(_query.MandatorUIDs, _query.IndividualPersonUID);

                if (individualPerson != null)
                {
                    if (individualPerson.MandatorUIDs.Intersect(_query.MandatorUIDs).Any())
                    {
                        string fullLink = Path.Combine(_query.PictureDirectoryPath, individualPerson.PictureLink);
                        if (Directory.Exists(fullLink))
                        {
                            System.IO.File.Delete(fullLink);

                            individualPerson.PictureLink = null;

                            uow.IndividualPersonRepository.Update(_query.MandatorUIDs, individualPerson);
                        }

                        throw new FileNotFoundException(string.Format("File {0} does not Exists", fullLink));
                    }

                    throw new UnauthorizedAccessException("Individual Person from another Mandator");
                }

                throw new DataException("No Entity found to UID : " + _query.IndividualPersonUID);
            }
            catch (DataException e)
            {
                throw new DataException("Internal Server Error", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException("Internal Server Error", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}