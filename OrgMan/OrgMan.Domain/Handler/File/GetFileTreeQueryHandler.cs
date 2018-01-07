using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.File;
using OrgMan.DomainObjects.Common;
using OrgMan.DomainObjects.File;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.Domain.Handler.File
{
    public class GetFileTreeQueryHandler : QueryHandlerBase
    {
        private readonly GetFileTreeQuery _query;
        private readonly OrgManUnitOfWork _uow;

        public GetFileTreeQueryHandler(GetFileTreeQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            _uow = new OrgManUnitOfWork();
        }

        public List<DirectoryDomainModel> Handle()
        {
            try
            {
                List<DirectoryDomainModel> directories = new List<DirectoryDomainModel>();

                foreach (var mandatorUid in _query.MandatorUIDs)
                {
                    MandatorDomainModel mandator = AutoMapper.Mapper.Map<MandatorDomainModel>(_uow.MandatorRepository.Get(mandatorUid));

                    if (mandator == null)
                    {
                        throw new DataException("Invalid MandatorUID");
                    }

                    DirectoryDomainModel directory = new DirectoryDomainModel()
                    {
                        Mandator = mandator,
                        Entries = new List<FileDomainModel>()
                    };

                    string rootPath = Path.Combine(_query.DirectoryPath, mandator.UID.ToString());

                    if (Directory.Exists(rootPath))
                    {
                        foreach (var dir in Directory.GetDirectories(rootPath))
                        {
                            directory.Entries.AddRange(LoopDirectory(rootPath));
                        }

                        directories.Add(directory);
                    }
                    else
                    {
                        throw new FileNotFoundException(string.Format("Directory {0} does not Exists", rootPath));
                    }
                }

                return directories;
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception e)
            {
                throw new Exception("Internal Server Error");
            }
        }

        private List<FileDomainModel> LoopDirectory(string path)
        {
            List<FileDomainModel> domainModels = new List<FileDomainModel>();

            foreach(var file in Directory.GetFiles(path))
            {
                domainModels.Add(new FileDomainModel()
                {
                    Name = Path.GetFileName(file)
                });
            }

            foreach(var directory in Directory.GetDirectories(path))
            {
                domainModels.Add(new FileDomainModel()
                {
                    Name = Path.GetFileName(directory),
                    Entries = LoopDirectory(directory)
                });    
            }

            return domainModels;
        }
    }
}