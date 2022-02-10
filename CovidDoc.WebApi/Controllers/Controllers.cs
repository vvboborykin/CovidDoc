
using CovidDoc.Model;
using CovidDoc.WebApi.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDoc.WebApi.Controllers
{
    /// <summary>
    /// WebApi контроллер для сущности EF модели Address
    /// </summary>
    public partial class AddressController : BaseController<Address>
    {
        public AddressController(ILogger<AddressController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели AppRole
    /// </summary>
    public partial class AppRoleController : BaseController<AppRole>
    {
        public AppRoleController(ILogger<AppRoleController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели AppUser
    /// </summary>
    public partial class AppUserController : BaseController<AppUser>
    {
        public AppUserController(ILogger<AppUserController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Doctor
    /// </summary>
    public partial class DoctorController : BaseController<Doctor>
    {
        public DoctorController(ILogger<DoctorController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Document
    /// </summary>
    public partial class DocumentController : BaseController<Document>
    {
        public DocumentController(ILogger<DocumentController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели DocumentStatus
    /// </summary>
    public partial class DocumentStatusController : BaseController<DocumentStatus>
    {
        public DocumentStatusController(ILogger<DocumentStatusController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Hospitalization
    /// </summary>
    public partial class HospitalizationController : BaseController<Hospitalization>
    {
        public HospitalizationController(ILogger<HospitalizationController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели IdentityDocument
    /// </summary>
    public partial class IdentityDocumentController : BaseController<IdentityDocument>
    {
        public IdentityDocumentController(ILogger<IdentityDocumentController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели IdentityDocumentType
    /// </summary>
    public partial class IdentityDocumentTypeController : BaseController<IdentityDocumentType>
    {
        public IdentityDocumentTypeController(ILogger<IdentityDocumentTypeController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели LabOrder
    /// </summary>
    public partial class LabOrderController : BaseController<LabOrder>
    {
        public LabOrderController(ILogger<LabOrderController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели LabResult
    /// </summary>
    public partial class LabResultController : BaseController<LabResult>
    {
        public LabResultController(ILogger<LabResultController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели LabService
    /// </summary>
    public partial class LabServiceController : BaseController<LabService>
    {
        public LabServiceController(ILogger<LabServiceController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Mis
    /// </summary>
    public partial class MisController : BaseController<Mis>
    {
        public MisController(ILogger<MisController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Organization
    /// </summary>
    public partial class OrganizationController : BaseController<Organization>
    {
        public OrganizationController(ILogger<OrganizationController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Patient
    /// </summary>
    public partial class PatientController : BaseController<Patient>
    {
        public PatientController(ILogger<PatientController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели RecurrenceDisease
    /// </summary>
    public partial class RecurrenceDiseaseController : BaseController<RecurrenceDisease>
    {
        public RecurrenceDiseaseController(ILogger<RecurrenceDiseaseController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели ReferralItem
    /// </summary>
    public partial class ReferralItemController : BaseController<ReferralItem>
    {
        public ReferralItemController(ILogger<ReferralItemController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели ReferralPack
    /// </summary>
    public partial class ReferralPackController : BaseController<ReferralPack>
    {
        public ReferralPackController(ILogger<ReferralPackController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели ResearchResult
    /// </summary>
    public partial class ResearchResultController : BaseController<ResearchResult>
    {
        public ResearchResultController(ILogger<ResearchResultController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели ResearchType
    /// </summary>
    public partial class ResearchTypeController : BaseController<ResearchType>
    {
        public ResearchTypeController(ILogger<ResearchTypeController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Signature
    /// </summary>
    public partial class SignatureController : BaseController<Signature>
    {
        public SignatureController(ILogger<SignatureController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Smso
    /// </summary>
    public partial class SmsoController : BaseController<Smso>
    {
        public SmsoController(ILogger<SmsoController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели SmsoConnection
    /// </summary>
    public partial class SmsoConnectionController : BaseController<SmsoConnection>
    {
        public SmsoConnectionController(ILogger<SmsoConnectionController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели SmsoEventType
    /// </summary>
    public partial class SmsoEventTypeController : BaseController<SmsoEventType>
    {
        public SmsoEventTypeController(ILogger<SmsoEventTypeController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели StatusTransition
    /// </summary>
    public partial class StatusTransitionController : BaseController<StatusTransition>
    {
        public StatusTransitionController(ILogger<StatusTransitionController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели TestReason
    /// </summary>
    public partial class TestReasonController : BaseController<TestReason>
    {
        public TestReasonController(ILogger<TestReasonController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели TestSystem
    /// </summary>
    public partial class TestSystemController : BaseController<TestSystem>
    {
        public TestSystemController(ILogger<TestSystemController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Vaccination
    /// </summary>
    public partial class VaccinationController : BaseController<Vaccination>
    {
        public VaccinationController(ILogger<VaccinationController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели VaccineType
    /// </summary>
    public partial class VaccineTypeController : BaseController<VaccineType>
    {
        public VaccineTypeController(ILogger<VaccineTypeController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

    /// <summary>
    /// WebApi контроллер для сущности EF модели Work
    /// </summary>
    public partial class WorkController : BaseController<Work>
    {
        public WorkController(ILogger<WorkController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }

}