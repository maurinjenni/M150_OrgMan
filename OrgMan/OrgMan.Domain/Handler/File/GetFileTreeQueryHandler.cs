using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.File;
using OrgMan.DomainObjects.Common;
using OrgMan.DomainObjects.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.Domain.Handler.File
{
    public class GetFileTreeQueryHandler : QueryHandlerBase
    {
        private readonly GetFileTreeQuery _query;

        public GetFileTreeQueryHandler(GetFileTreeQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public List<DirectoryDomainModel> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            List<DirectoryDomainModel> directories = new List<DirectoryDomainModel>();

            foreach(var mandatorUid in _query.MandatorUIDs)
            {
                MandatorDomainModel mandator = AutoMapper.Mapper.Map<MandatorDomainModel>(uow.MandatorRepository.Get(mandatorUid));

                string rootPath = Path.Combine(_query.DirectoryPath, mandator.Title);

                DirectoryDomainModel directory = new DirectoryDomainModel()
                {
                    Mandator = mandator,
                    Entries = new List<FileDomainModel>()
                };

                foreach (var dir in Directory.GetDirectories(rootPath))
                {
                    directory.Entries.AddRange(LoopDirectory(rootPath));
                }

                directories.Add(directory);
            }

            return directories;
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