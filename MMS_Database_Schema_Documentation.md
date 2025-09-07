# Military Management System (MMS) Database Schema Documentation

## Table of Contents
1. [Overview](#overview)
2. [Database Architecture](#database-architecture)
3. [Core Modules](#core-modules)
4. [Entity Relationships](#entity-relationships)
5. [Initial Registration Module](#initial-registration-module)
6. [Business Rules and Constraints](#business-rules-and-constraints)
7. [Integration Points](#integration-points)

---

## Overview

The Military Management System (MMS) is a comprehensive database system designed to manage military personnel, registration processes, and administrative operations. This document provides a complete overview of all database tables, entities, and their relationships organized by functional modules.

### System Architecture Principles
- **Person-Centric Design**: All data revolves around the Person entity
- **Audit Trail**: Complete change tracking for all critical operations
- **Soft Delete**: Data preservation with logical deletion
- **Modular Structure**: Clear separation of concerns by functional modules
- **Integration Ready**: Built for external system integrations (ƏDR, İAMAS, ETN, DTSERA)

---

## Database Architecture

### Base Entity Framework

#### Core Base Classes
```
BaseEntity (Abstract)
├── Domain Events Support
├── Entity Identification
└── Base Functionality

AuditableEntity : BaseEntity
├── CreatedBy, CreatedOn
├── LastModifiedBy, LastModifiedOn
└── IsDeleted, DeletedBy, DeletedOn
```

#### Design Patterns
- **Repository Pattern**: Data access abstraction
- **Unit of Work**: Transaction management
- **Domain Events**: Business logic decoupling
- **Soft Delete Interface**: `ISoftDelete` implementation
- **Normalized Names**: Efficient searching and comparison

---

## Core Modules

### 1. Account Management Module

#### 1.1 User Management Entities

**User** - Core user authentication and authorization
```
Properties:
├── Authentication: Username, NormalizedUsername, PasswordHash
├── Security: FailedLoginAttempts, LockoutEndsOn, ForcePasswordChange
├── Tracking: LastLoginOn, LastLoginIp, LastLoginUserAgent
├── Configuration: IsEnabled, UserTypeId, PersonId
└── Domain: DomainAccount, PasswordChangedOn

Navigation:
├── Person (1:1)
├── UserType (N:1)
├── PasswordHistories (1:N)
├── UserRoles (1:N)
└── UserHistories (1:N)
```

**Person** - Central entity for personal information
```
Properties:
├── Identity: Name, Surname, FatherName, NormalizedFullName
├── Demographics: BirthDate, GenderId, PinCode
├── Status: IsActive, IsActiveReason, SourceTypeId
└── Metadata: Audit fields

Navigation:
├── User (1:1)
├── Gender (N:1)
├── Documents (1:N)
├── Contacts (1:N)
└── Workplaces (1:N)
```

#### 1.2 Document Management Entities

**PersonDocument** - Official document management
```
Properties:
├── Document Info: Serial, Number, ProtocolNumber
├── Validity: IssuedDate, ExpireDate, IsActive
├── Issuer: IssuedByMilitaryEnlistmentId, CountryId
├── Organization: IssuedByOrganizationName
└── Termination: DocumentTerminationReasonId, TerminationDate

Navigation:
├── Person (N:1)
├── DocumentType (N:1)
├── Files (1:N)
└── History (1:N)
```

#### 1.3 Workplace Management

**PersonWorkplace** - Employment and assignment tracking
```
Properties:
├── Assignment: MilitaryEnlistmentId, InternalOrganizationalUnitId
├── Position: PositionId, JobTypeId, MilitaryRankId
├── Organization: RepresentativeOrganizationId, TroopTypeId
├── Period: StartDate, EndDate, IsActive
└── Special: IsSubstituteChiefPosition

Navigation:
├── Person (N:1)
├── MilitaryEnlistment (N:1)
├── Position (N:1)
└── History (1:N)
```

#### 1.4 Security Framework

**Authorization Entities:**
- **Role** - System roles with hierarchical permissions
- **Permission** - Granular system permissions
- **RolePermission** - Role-permission mappings
- **UserRole** - User-role assignments

**Security Entities:**
- **PasswordHistory** - Password change tracking
- **PasswordPolicy** - Password complexity rules
- **RefreshToken** - JWT token management

### 2. Reference Data Module

#### 2.1 Geographic and Administrative
- **Country** - International country codes and names
- **Region** - Administrative territorial divisions
- **RegionType** - Classification of regional types
- **RegionTypeCode** - Standardized region coding

#### 2.2 Organizational Structure
- **Organization** - External organizations and institutions
- **OrganizationGroup** - Organization categorization
- **InternalOrganizationalUnit** - Internal department structure
- **Position** - Job positions and titles
- **JobType** - Employment classification types

#### 2.3 Military Structure
- **MilitaryEnlistment** - Military registration offices
- **MilitaryEnlistmentType** - Classification of enlistment types
- **MilitaryRank** - Military hierarchy ranks
- **MilitaryStructure** - Organizational military units
- **TroopType** - Military service branch types

#### 2.4 Document Types
- **DocumentType** - Official document categories
- **DocumentTypeSerial** - Document serial number management
- **DocumentStatus** - Document lifecycle states
- **DocumentTerminationReason** - Document invalidation reasons

#### 2.5 Medical System
- **MedicalInstitution** - Healthcare facilities
- **MedicalInstitutionType** - Medical facility categories
- **Disease** - Medical condition catalog
- **InternationalClassificationOfDisease** - ICD-10 codes
- **UsabilityStatus** - Medical fitness classifications

#### 2.6 Military Professions
- **MilitaryOfficerSpeciality** - Officer specialty codes
- **MilitaryProfessionGroup** - Professional groupings
- **MilitaryProfessionSpecialty** - Specialized military skills
- **MilitarySpecialRequirement** - Position-specific requirements

### 3. Management Module

#### 3.1 Document Registration System

**OfficialDocumentRegistration** - Document lifecycle management
```
Properties:
├── Document: DocumentTypeSerialId, Number
├── Status: DocumentStatusId
├── Assignment: MilitaryEnlistmentId
└── Reference: PersonDocumentId

Navigation:
├── DocumentTypeSerial (N:1)
├── DocumentStatus (N:1)
├── MilitaryEnlistment (N:1)
└── History (1:N)
```

#### 3.2 Support Ticket System

**SupportTicket** - Issue tracking and resolution
```
Properties:
├── Identification: TicketCode, MilitaryEnlistmentId
├── Classification: TypeId, ReasonId, PriorityId
├── Status: StatusId, Content
└── Metadata: Audit fields

Navigation:
├── Type, Reason, Priority, Status (N:1)
├── Assignments (1:N)
├── Comments (1:N)
├── Files (1:N)
└── History (1:N)
```

#### 3.3 File Transfer System

**FileTransfer** - Secure file sharing
```
Properties:
├── File Info: Name, OriginalName, FileName, FilePath
├── Security: PasswordHash, MaxPasswordFailedAttempt
├── Tracking: RecipientCount, DownloadedCount
├── Status: IsActive, IsRead, FileTransferStatusId
└── Network: IpAddress, MilitaryEnlistmentId

Navigation:
├── Recipients (1:N)
├── History (1:N)
└── Status (N:1)
```

---

## Entity Relationships

### Core Relationship Patterns

#### 1. Person-Centric Architecture
```
Person (Central Hub)
├── User (1:1) - Authentication
├── PersonDocument (1:N) - Official documents
├── PersonWorkplace (1:N) - Employment history
├── PersonContact (1:N) - Communication channels
└── InitialRegistrationCandidate (1:1) - Registration link
```

#### 2. Document Management Flow
```
Document Lifecycle:
PersonDocument → OfficialDocumentRegistration → DocumentStatus
     ↓                        ↓                        ↓
DocumentType           DocumentTypeSerial      Status Transitions
```

#### 3. Military Structure Hierarchy
```
MilitaryEnlistment
├── PersonWorkplace (Assignment)
├── OfficialDocumentRegistration (Processing)
├── SupportTicket (Support)
└── InitialRegistrationCandidate (Registration)
```

---

## Initial Registration Module

### Module Purpose
The Initial Registration Module manages the complete lifecycle of military registration candidates from initial data collection through final registration completion.

### 5.1 Core Registration Entities

#### **InitialRegistrationCandidate** - Primary candidate management
```
Properties:
├── Identity: PinCode, FirstName, LastName, MiddleName
├── Demographics: BirthDate, BirthCountry, PlaceOfBirth, Gender
├── Location: RegistrationAddress
├── Processing: DataSource, AddedDate, RegistrationStatus
├── Assignment: AssignedMilitaryEnlistmentId
├── Status Management: Status, RemovalStatus, RemovalReason
├── Lifecycle: RemovalNote, RemovalDate, RestoredDate, IsActive
└── Audit: Standard audit fields

Navigation:
├── AssignedMilitaryEnlistment (N:1)
├── RemovalReasonCatalog (N:1)
├── History (1:N)
├── Documents (1:N)
├── Contacts (1:N)
├── Relatives (1:N)
├── Education (1:N)
└── Disability (1:N)
```

#### **InitialRegistrationEnlisted** - Active registration processing
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Identity: PinCode, FirstName, LastName, MiddleName
├── Demographics: BirthDate, BirthCountry, PlaceOfBirth, Gender
├── Location: RegistrationAddress
├── Assignment: AssignedMilitaryEnlistmentId
├── Status: Status, DecisionWaitingReason
├── Processing: AddedDate, IsActive
├── Integration: MyGovStatus, LastExaminationStatus
└── Audit: Standard audit fields

Navigation:
├── InitialRegistrationCandidate (N:1)
├── AssignedMilitaryEnlistment (N:1)
├── History (1:N)
└── Examinations (1:N)
```

### 5.2 Data Collection Entities

#### **InitialRegistrationCandidateDocument** - Document data from ƏDR/İAMAS
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Document: DocumentSerial, DocumentNumber
├── Validity: IssueDate, ExpiryDate
├── Issuer: IssuedByOrganization
└── Status: IsActive, DocumentStatus
```

#### **InitialRegistrationCandidateContact** - Communication information
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Contact: ContactType, ContactValue
└── Priority: IsPrimary
```

#### **InitialRegistrationCandidateRelative** - Family relationship data
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Identity: RelativePinCode, RelativeFirstName, RelativeLastName
├── Demographics: RelativeMiddleName, RelativeBirthDate, RelativeGender
└── Relationship: RelationshipType
```

#### **InitialRegistrationCandidateEducation** - Educational data from ETN
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Institution: InstitutionName, InstitutionRegion
├── Academic: ClassLevel, ClassProfile
└── Details: TeachingLanguage, EducationForm
```

#### **InitialRegistrationCandidateDisability** - Disability data from DTSERA
```
Properties:
├── Reference: InitialRegistrationCandidateId
├── Assessment: DisabilityDegree, ExaminationDate, NextExaminationDate
└── Classification: XBTCode1, XBTCode2, XBTCode3, XBTCode4, XBTCode5, XBTCode6
```

### 5.3 Process Management Entities

#### **InitialRegistrationExamination** - Medical examination tracking
```
Properties:
├── Reference: InitialRegistrationEnlistedId
├── Type: ExaminationType (Mütləq/Əlavə müayinə)
├── Status: ExaminationStatus
├── Scheduling: SentDate, ExaminationDate
├── Results: Result, Notes
└── Audit: Standard audit fields
```

### 5.4 Catalog Entities

#### Status Management Catalogs
- **InitialRegistrationStatus** - Registration process states
- **DecisionWaitingReason** - Decision delay explanations
- **RemovalReason** - Candidate removal justifications
- **RegistrationStatus** - Registration phase indicators
- **ExaminationStatus** - Medical examination states
- **ExaminationType** - Examination category classification

### 5.5 Integration Support Entities

#### **IntegrationLog** - External system communication tracking
```
Properties:
├── Service: ServiceName
├── Communication: RequestData, ResponseData
├── Status: Status, ErrorMessage
├── Timing: RequestDate, ResponseDate, ProcessingTime
└── Performance: Processing metrics
```

#### **DataSyncStatus** - Synchronization state management
```
Properties:
├── Identity: PinCode, ServiceName
├── Sync: LastSyncDate, SyncStatus
├── Error: ErrorMessage, RetryCount
└── Tracking: Sync attempt history
```

---

## Business Rules and Constraints

### 6.1 Age-Based Processing Rules

#### Age Categories and Processing
```
Age Group          | Processing Rule                    | Special Conditions
14-15 years       | Next year will be 15             | Future registration
15-17.9 years     | Current conscription age          | Active processing
18+ years         | Exceeded age limit                | Cannot be restored
```

### 6.2 Military Enlistment Assignment Rules

#### Special Region Mappings
```
Source Region     | Target Assignment        | Rule Type
Xankəndi         | Xocalı rayon            | Manual override
Naftalan         | Goranboy rayon          | Manual override
Pirallahı        | Xəzər rayon             | Manual override
Others           | Statistical code based   | Automatic assignment
```

### 6.3 Status Transition Rules

#### Registration Status Flow
```
YSB təyin edilməyib
    ↓
YSB təyin edilib
    ↓
Qeydiyyat gözlənilir
    ↓
Natamam qeydiyyatdadır
    ↓
Qərar verilməyib
    ↓
Qərar gözlənilir
    ↓
İlkin qeydiyyat tamamlanıb
```

#### Decision Waiting Reasons
- **Mütləq müayinəyə göndərilib** - Sent for mandatory examination
- **Mütləq müayinə yekunlaşmışdır** - Mandatory examination completed
- **Əlavə müayinəyə göndərilib** - Sent for additional examination
- **Əlavə müayinə yekunlaşıb** - Additional examination completed

### 6.4 Data Retention Policies

#### Removal and Restoration Rules
- Removed candidates remain in system (soft delete)
- Restoration possible until age 18
- Complete deletion process does not exist
- Historical data preserved for audit purposes

#### Removal Reasons
- **Məhkum olunduğu üçün** - Due to criminal conviction
- **Vəfat etdiyi üçün** - Due to death
- **Vətəndaşlığı itirdiyi üçün** - Due to loss of citizenship
- **Dublikat FİN** - Duplicate identification number
- **Cinsi səhv göstəridiyi üçün** - Due to incorrect gender specification

---

## Integration Points

### 7.1 External System Integrations

#### **ƏDR (Əhalinin Dövlət Reyestri)** - Population State Registry
```
Data Retrieved:
├── Personal Identity: Full name, FIN, Birth date
├── Demographics: Gender, Birth place
├── Citizenship: Citizenship status
└── Updates: Real-time synchronization
```

#### **İAMAS (İcbari Tibbi Sığorta Məlumat Sistemi)** - Mandatory Medical Insurance
```
Data Retrieved:
├── Detailed Personal Info: Address, contacts
├── Family Relations: Relative information
├── Medical Insurance: Coverage details
└── Contact Information: Phone, email, address
```

#### **ETN (Elektron Təhsil Şəbəkəsi)** - Electronic Education Network
```
Data Retrieved:
├── Educational Institution: School name, region
├── Academic Level: Class level, profile
├── Language: Teaching language
└── Form: Education form (full-time, part-time)
```

#### **DTSERA (Dövlət Tibbi-Sosial Ekspertiza və Reabilitasiya Agentliyi)** - Medical-Social Expertise
```
Data Retrieved:
├── Disability Assessment: Degree, examination dates
├── Medical Classification: XBT codes (6 categories)
├── Examination Schedule: Current and next examination
└── Medical Fitness: Usability status
```

### 7.2 Integration Architecture

#### Data Flow Pattern
```
External Service → IntegrationLog → DataSyncStatus → Candidate Tables
                      ↓                  ↓              ↓
                Error Tracking    Sync Status    Processed Data
```

#### Error Handling and Retry Logic
- **Retry Mechanism**: Configurable retry attempts
- **Error Logging**: Comprehensive error tracking
- **Status Monitoring**: Real-time sync status
- **Data Validation**: Multi-level validation checks

### 7.3 Data Migration to Core System

#### Migration Process Flow
```
Initial Registration Complete
    ↓
Person Entity Creation
    ↓
User Account Setup
    ↓
Document Registration
    ↓
Workplace Assignment
    ↓
Integration Complete
```

#### Migration Data Mapping
```
InitialRegistrationCandidate → Person
├── Identity fields → Person identity
├── Demographics → Person demographics
├── Documents → PersonDocument
├── Contacts → PersonContact
└── Status → Person.IsActive
```

---

## Conclusion

This database schema provides a comprehensive foundation for military personnel management with specific focus on the initial registration process. The modular design ensures scalability, maintainability, and integration capabilities while maintaining data integrity and audit trails throughout all operations.

### Key Strengths
- **Comprehensive Coverage**: All aspects of military personnel management
- **Integration Ready**: Built for external system connectivity
- **Audit Compliant**: Complete change tracking and history
- **Scalable Architecture**: Modular design for future expansion
- **Business Rule Enforcement**: Built-in constraint management

### Future Considerations
- Performance optimization for large datasets
- Advanced reporting and analytics capabilities
- Mobile application support
- Enhanced security features
- Workflow automation capabilities