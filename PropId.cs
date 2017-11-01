﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    /// <summary>
    /// Property ID
    /// </summary>
    /// <remarks>
    /// See,
    /// [MS-OXPROPS]: Exchange Server Protocols Master Property List
    /// https://msdn.microsoft.com/en-us/library/cc433490(v=exchg.80).aspx
    /// </remarks>
    public enum PropId {
        PidTagAccess = 0x0FF4,
        PidTagAccessControlListData = 0x3FE0,
        PidTagAccessLevel = 0x0FF7,
        PidTagAccount = 0x3A00,
        PidTagAdditionalRenEntryIds = 0x36D9,
        PidTagAddressBookAuthorizedSenders = 0x8CD8,
        PidTagAddressBookContainerId = 0xFFFD,
        PidTagAddressBookDeliveryContentLength = 0x806A,
        PidTagAddressBookDisplayNamePrintable = 0x39FF,
        PidTagAddressBookDisplayTypeExtended = 0x8C93,
        PidTagAddressBookDistributionListExternalMemberCount = 0x8CE3,
        PidTagAddressBookDistributionListMemberCount = 0x8CE2,
        PidTagAddressBookDistributionListMemberSubmitAccepted = 0x8073,
        PidTagAddressBookDistributionListMemberSubmitRejected = 0x8CDA,
        PidTagAddressBookDistributionListRejectMessagesFromDLMembers = 0x8CDB,
        PidTagAddressBookEntryId = 0x663B,
        PidTagAddressBookExtensionAttribute1 = 0x802D,
        PidTagAddressBookExtensionAttribute10 = 0x8036,
        PidTagAddressBookExtensionAttribute11 = 0x8C57,
        PidTagAddressBookExtensionAttribute12 = 0x8C58,
        PidTagAddressBookExtensionAttribute13 = 0x8C60,
        PidTagAddressBookExtensionAttribute15 = 0x8C61,
        PidTagAddressBookExtensionAttribute2 = 0x802E,
        PidTagAddressBookExtensionAttribute3 = 0x802F,
        PidTagAddressBookExtensionAttribute4 = 0x8030,
        PidTagAddressBookExtensionAttribute5 = 0x8031,
        PidTagAddressBookExtensionAttribute6 = 0x8032,
        PidTagAddressBookExtensionAttribute7 = 0x8033,
        PidTagAddressBookExtensionAttribute8 = 0x8034,
        PidTagAddressBookExtensionAttribute9 = 0x8035,
        PidTagAddressBookFolderPathname = 0x8004,
        PidTagAddressBookHierarchicalChildDepartments = 0x8C9A,
        PidTagAddressBookHierarchicalDepartmentMembers = 0x8C97,
        PidTagAddressBookHierarchicalIsHierarchicalGroup = 0x8CDD,
        PidTagAddressBookHierarchicalParentDepartment = 0x8C99,
        PidTagAddressBookHierarchicalRootDepartment = 0x8C98,
        PidTagAddressBookHierarchicalShowInDepartments = 0x8C94,
        PidTagAddressBookHomeMessageDatabase = 0x8006,
        PidTagAddressBookIsMaster = 0xFFFB,
        PidTagAddressBookIsMemberOfDistributionList = 0x8008,
        PidTagAddressBookManageDistributionList = 0x6704,
        PidTagAddressBookManager = 0x8005,
        PidTagAddressBookManagerDistinguishedName = 0x8005,
        PidTagAddressBookMember = 0x8009,
        PidTagAddressBookMessageId = 0x674F,
        PidTagAddressBookModerationEnabled = 0x8CB5,
        PidTagAddressBookNetworkAddress = 0x8170,
        PidTagAddressBookObjectDistinguishedName = 0x803C,
        PidTagAddressBookObjectGuid = 0x8C6D,
        PidTagAddressBookOrganizationalUnitRootDistinguishedName = 0x8CA8,
        PidTagAddressBookOwner = 0x800C,
        PidTagAddressBookOwnerBackLink = 0x8024,
        PidTagAddressBookParentEntryId = 0xFFFC,
        PidTagAddressBookPhoneticCompanyName = 0x8C91,
        PidTagAddressBookPhoneticDepartmentName = 0x8C90,
        PidTagAddressBookPhoneticDisplayName = 0x8C92,
        PidTagAddressBookPhoneticGivenName = 0x8C8E,
        PidTagAddressBookPhoneticSurname = 0x8C8F,
        PidTagAddressBookProxyAddresses = 0x800F,
        PidTagAddressBookPublicDelegates = 0x8015,
        PidTagAddressBookReports = 0x800E,
        PidTagAddressBookRoomCapacity = 0x0807,
        PidTagAddressBookRoomContainers = 0x8C96,
        PidTagAddressBookRoomDescription = 0x0809,
        PidTagAddressBookSenderHintTranslations = 0x8CAC,
        PidTagAddressBookSeniorityIndex = 0x8CA0,
        PidTagAddressBookTargetAddress = 0x8CD9,
        PidTagAddressBookX509Certificate = 0x8C6A,
        PidTagAddressType = 0x3002,
        PidTagAlternateRecipientAllowed = 0x0002,
        PidTagAnr = 0x360C,
        PidTagArchiveDate = 0x301F,
        PidTagArchivePeriod = 0x301E,
        PidTagArchiveTag = 0x3018,
        PidTagAssistant = 0x3A30,
        PidTagAssistantTelephoneNumber = 0x3A2E,
        PidTagAssociated = 0x67AA,
        PidTagAttachAdditionalInformation = 0x370F,
        PidTagAttachContentBase = 0x3711,
        PidTagAttachContentId = 0x3712,
        PidTagAttachContentLocation = 0x3713,
        PidTagAttachDataBinary = 0x3701,
        PidTagAttachDataObject = 0x3701,
        PidTagAttachEncoding = 0x3702,
        PidTagAttachExtension = 0x3703,
        PidTagAttachFilename = 0x3714,
        PidTagAttachLongFilename = 0x3707,
        PidTagAttachLongPathname = 0x370D,
        PidTagAttachmentContactPhoto = 0x7FFF,
        PidTagAttachmentFlags = 0x7FFD,
        PidTagAttachmentHidden = 0x7FFE,
        PidTagAttachmentLinkId = 0x7FFA,
        PidTagAttachMethod = 0x3705,
        PidTagAttachMimeTag = 0x370E,
        PidTagAttachNumber = 0x0E21,
        PidTagAttachPathname = 0x3708,
        PidTagAttachPayloadClass = 0x371A,
        PidTagAttachPayloadProviderGuidString = 0x3719,
        PidTagAttachRendering = 0x3709,
        PidTagAttachSize = 0x0E20,
        PidTagAttachTag = 0x370A,
        PidTagAttachTransportName = 0x370C,
        PidTagAttributeHidden = 0x10F4,
        PidTagAttributeReadOnly = 0x10F6,
        PidTagAutoForwardComment = 0x0004,
        PidTagAutoForwarded = 0x0005,
        PidTagAutoResponseSuppress = 0x3FDF,
        PidTagBirthday = 0x3A42,
        PidTagBlockStatus = 0x1096,
        PidTagBody = 0x1000,
        PidTagBodyContentId = 0x1015,
        PidTagBodyContentLocation = 0x1014,
        PidTagBodyHtml = 0x1013,
        PidTagBusiness2TelephoneNumber = 0x3A1B,
        PidTagBusiness2TelephoneNumbers = 0x3A1B,
        PidTagBusinessFaxNumber = 0x3A24,
        PidTagBusinessHomePage = 0x3A51,
        PidTagBusinessTelephoneNumber = 0x3A08,
        PidTagCallbackTelephoneNumber = 0x3A02,
        PidTagCallId = 0x6806,
        PidTagCarTelephoneNumber = 0x3A1E,
        PidTagCdoRecurrenceid = 0x10C5,
        PidTagChangeKey = 0x65E2,
        PidTagChangeNumber = 0x67A4,
        PidTagChildrensNames = 0x3A58,
        PidTagClientActions = 0x6645,
        PidTagClientSubmitTime = 0x0039,
        PidTagCodePageId = 0x66C3,
        PidTagComment = 0x3004,
        PidTagCompanyMainTelephoneNumber = 0x3A57,
        PidTagCompanyName = 0x3A16,
        PidTagComputerNetworkName = 0x3A49,
        PidTagConflictEntryId = 0x3FF0,
        PidTagContainerClass = 0x3613,
        PidTagContainerContents = 0x360F,
        PidTagContainerFlags = 0x3600,
        PidTagContainerHierarchy = 0x360E,
        PidTagContentCount = 0x3602,
        PidTagContentFilterSpamConfidenceLevel = 0x4076,
        PidTagContentUnreadCount = 0x3603,
        PidTagConversationId = 0x3013,
        PidTagConversationIndex = 0x0071,
        PidTagConversationIndexTracking = 0x3016,
        PidTagConversationTopic = 0x0070,
        PidTagCountry = 0x3A26,
        PidTagCreationTime = 0x3007,
        PidTagCreatorEntryId = 0x3FF9,
        PidTagCreatorName = 0x3FF8,
        PidTagCustomerId = 0x3A4A,
        PidTagDamBackPatched = 0x6647,
        PidTagDamOriginalEntryId = 0x6646,
        PidTagDefaultPostMessageClass = 0x36E5,
        PidTagDeferredActionMessageOriginalEntryId = 0x6741,
        PidTagDeferredDeliveryTime = 0x000F,
        PidTagDeferredSendNumber = 0x3FEB,
        PidTagDeferredSendTime = 0x3FEF,
        PidTagDeferredSendUnits = 0x3FEC,
        PidTagDelegatedByRule = 0x3FE3,
        PidTagDelegateFlags = 0x686B,
        PidTagDeleteAfterSubmit = 0x0E01,
        PidTagDeletedCountTotal = 0x670B,
        PidTagDeletedOn = 0x668F,
        PidTagDeliverTime = 0x0010,
        PidTagDepartmentName = 0x3A18,
        PidTagDepth = 0x3005,
        PidTagDisplayBcc = 0x0E02,
        PidTagDisplayCc = 0x0E03,
        PidTagDisplayName = 0x3001,
        PidTagDisplayNamePrefix = 0x3A45,
        PidTagDisplayTo = 0x0E04,
        PidTagDisplayType = 0x3900,
        PidTagDisplayTypeEx = 0x3905,
        PidTagEmailAddress = 0x3003,
        PidTagEndDate = 0x0061,
        PidTagEntryId = 0x0FFF,
        PidTagExceptionEndTime = 0x7FFC,
        PidTagExceptionReplaceTime = 0x7FF9,
        PidTagExceptionStartTime = 0x7FFB,
        PidTagExchangeNTSecurityDescriptor = 0x0E84,
        PidTagExpiryNumber = 0x3FED,
        PidTagExpiryTime = 0x0015,
        PidTagExpiryUnits = 0x3FEE,
        PidTagExtendedFolderFlags = 0x36DA,
        PidTagExtendedRuleMessageActions = 0x0E99,
        PidTagExtendedRuleMessageCondition = 0x0E9A,
        PidTagExtendedRuleSizeLimit = 0x0E9B,
        PidTagFaxNumberOfPages = 0x6804,
        PidTagFlagCompleteTime = 0x1091,
        PidTagFlagStatus = 0x1090,
        PidTagFlatUrlName = 0x670E,
        PidTagFolderAssociatedContents = 0x3610,
        PidTagFolderId = 0x6748,
        PidTagFolderFlags = 0x66A8,
        PidTagFolderType = 0x3601,
        PidTagFollowupIcon = 0x1095,
        PidTagFreeBusyCountMonths = 0x6869,
        PidTagFreeBusyEntryIds = 0x36E4,
        PidTagFreeBusyMessageEmailAddress = 0x6849,
        PidTagFreeBusyPublishEnd = 0x6848,
        PidTagFreeBusyPublishStart = 0x6847,
        PidTagFreeBusyRangeTimestamp = 0x6868,
        PidTagFtpSite = 0x3A4C,
        PidTagGatewayNeedsToRefresh = 0x6846,
        PidTagGender = 0x3A4D,
        PidTagGeneration = 0x3A05,
        PidTagGivenName = 0x3A06,
        PidTagGovernmentIdNumber = 0x3A07,
        PidTagHasAttachments = 0x0E1B,
        PidTagHasDeferredActionMessages = 0x3FEA,
        PidTagHasNamedProperties = 0x664A,
        PidTagHasRules = 0x663A,
        PidTagHierarchyChangeNumber = 0x663E,
        PidTagHierRev = 0x4082,
        PidTagHobbies = 0x3A43,
        PidTagHome2TelephoneNumber = 0x3A2F,
        PidTagHome2TelephoneNumbers = 0x3A2F,
        PidTagHomeAddressCity = 0x3A59,
        PidTagHomeAddressCountry = 0x3A5A,
        PidTagHomeAddressPostalCode = 0x3A5B,
        PidTagHomeAddressPostOfficeBox = 0x3A5E,
        PidTagHomeAddressStateOrProvince = 0x3A5C,
        PidTagHomeAddressStreet = 0x3A5D,
        PidTagHomeFaxNumber = 0x3A25,
        PidTagHomeTelephoneNumber = 0x3A09,
        PidTagHtml = 0x1013,
        PidTagICalendarEndTime = 0x10C4,
        PidTagICalendarReminderNextTime = 0x10CA,
        PidTagICalendarStartTime = 0x10C3,
        PidTagIconIndex = 0x1080,
        PidTagImportance = 0x0017,
        PidTagInConflict = 0x666C,
        PidTagInitialDetailsPane = 0x3F08,
        PidTagInitials = 0x3A0A,
        PidTagInReplyToId = 0x1042,
        PidTagInstanceKey = 0x0FF6,
        PidTagInstanceNum = 0x674E,
        PidTagInstID = 0x674D,
        PidTagInternetCodepage = 0x3FDE,
        PidTagInternetMailOverrideFormat = 0x5902,
        PidTagInternetMessageId = 0x1035,
        PidTagInternetReferences = 0x1039,
        PidTagIpmAppointmentEntryId = 0x36D0,
        PidTagIpmContactEntryId = 0x36D1,
        PidTagIpmDraftsEntryId = 0x36D7,
        PidTagIpmJournalEntryId = 0x36D2,
        PidTagIpmNoteEntryId = 0x36D3,
        PidTagIpmTaskEntryId = 0x36D4,
        PidTagIsdnNumber = 0x3A2D,
        PidTagJunkAddRecipientsToSafeSendersList = 0x6103,
        PidTagJunkIncludeContacts = 0x6100,
        PidTagJunkPermanentlyDelete = 0x6102,
        PidTagJunkPhishingEnableLinks = 0x6107,
        PidTagJunkThreshold = 0x6101,
        PidTagKeyword = 0x3A0B,
        PidTagLanguage = 0x3A0C,
        PidTagLastModificationTime = 0x3008,
        PidTagLastModifierEntryId = 0x3FFB,
        PidTagLastModifierName = 0x3FFA,
        PidTagLastVerbExecuted = 0x1081,
        PidTagLastVerbExecutionTime = 0x1082,
        PidTagListHelp = 0x1043,
        PidTagListSubscribe = 0x1044,
        PidTagListUnsubscribe = 0x1045,
        PidTagLocalCommitTime = 0x6709,
        PidTagLocalCommitTimeMax = 0x670A,
        PidTagLocaleId = 0x66A1,
        PidTagLocality = 0x3A27,
        PidTagLocation = 0x3A0D,
        PidTagMailboxOwnerEntryId = 0x661B,
        PidTagMailboxOwnerName = 0x661C,
        PidTagManagerName = 0x3A4E,
        PidTagMappingSignature = 0x0FF8,
        PidTagMaximumSubmitMessageSize = 0x666D,
        PidTagMemberId = 0x6672,
        PidTagMemberRights = 0x6673,
        PidTagMessageAttachments = 0x0E13,
        PidTagMessageCcMe = 0x0058,
        PidTagMessageClass = 0x001A,
        PidTagMessageCodepage = 0x3FFD,
        PidTagMessageDeliveryTime = 0x0E06,
        PidTagMessageEditorFormat = 0x5909,
        PidTagMessageFlags = 0x0E07,
        PidTagMessageHandlingSystemCommonName = 0x3A0F,
        PidTagMessageLocaleId = 0x3FF1,
        PidTagMessageRecipientMe = 0x0059,
        PidTagMessageRecipients = 0x0E12,
        PidTagMessageSize = 0x0E08,
        PidTagMessageSizeExtended = 0x0E08,
        PidTagMessageStatus = 0x0E17,
        PidTagMessageSubmissionId = 0x0047,
        PidTagMessageToMe = 0x0057,
        PidTagMid = 0x674A,
        PidTagMiddleName = 0x3A44,
        PidTagMimeSkeleton = 0x64F0,
        PidTagMobileTelephoneNumber = 0x3A1C,
        PidTagNativeBody = 0x1016,
        PidTagNextSendAcct = 0x0E29,
        PidTagNickname = 0x3A4F,
        PidTagNonDeliveryReportDiagCode = 0x0C05,
        PidTagNonDeliveryReportReasonCode = 0x0C04,
        PidTagNonDeliveryReportStatusCode = 0x0C20,
        PidTagNonReceiptNotificationRequested = 0x0C06,
        PidTagNormalizedSubject = 0x0E1D,
        PidTagObjectType = 0x0FFE,
        PidTagOfficeLocation = 0x3A19,
        PidTagOfflineAddressBookContainerGuid = 0x6802,
        PidTagOfflineAddressBookDistinguishedName = 0x6804,
        PidTagOfflineAddressBookMessageClass = 0x6803,
        PidTagOfflineAddressBookName = 0x6800,
        PidTagOfflineAddressBookSequence = 0x6801,
        PidTagOfflineAddressBookTruncatedProperties = 0x6805,
        PidTagOrdinalMost = 0x36E2,
        PidTagOrganizationalIdNumber = 0x3A10,
        PidTagOriginalAuthorEntryId = 0x004C,
        PidTagOriginalAuthorName = 0x004D,
        PidTagOriginalDeliveryTime = 0x0055,
        PidTagOriginalDisplayBcc = 0x0072,
        PidTagOriginalDisplayCc = 0x0073,
        PidTagOriginalDisplayTo = 0x0074,
        PidTagOriginalEntryId = 0x3A12,
        PidTagOriginalMessageClass = 0x004B,
        PidTagOriginalMessageId = 0x1046,
        PidTagOriginalSenderAddressType = 0x0066,
        PidTagOriginalSenderEmailAddress = 0x0067,
        PidTagOriginalSenderEntryId = 0x005B,
        PidTagOriginalSenderName = 0x005A,
        PidTagOriginalSenderSearchKey = 0x005C,
        PidTagOriginalSensitivity = 0x002E,
        PidTagOriginalSentRepresentingAddressType = 0x0068,
        PidTagOriginalSentRepresentingEmailAddress = 0x0069,
        PidTagOriginalSentRepresentingEntryId = 0x005E,
        PidTagOriginalSentRepresentingName = 0x005D,
        PidTagOriginalSentRepresentingSearchKey = 0x005F,
        PidTagOriginalSubject = 0x0049,
        PidTagOriginalSubmitTime = 0x004E,
        PidTagOriginatorDeliveryReportRequested = 0x0023,
        PidTagOriginatorNonDeliveryReportRequested = 0x0C08,
        PidTagOscSyncEnabled = 0x7C24,
        PidTagOtherAddressCity = 0x3A5F,
        PidTagOtherAddressCountry = 0x3A60,
        PidTagOtherAddressPostalCode = 0x3A61,
        PidTagOtherAddressPostOfficeBox = 0x3A64,
        PidTagOtherAddressStateOrProvince = 0x3A62,
        PidTagOtherAddressStreet = 0x3A63,
        PidTagOtherTelephoneNumber = 0x3A1F,
        PidTagOutOfOfficeState = 0x661D,
        PidTagOwnerAppointmentId = 0x0062,
        PidTagPagerTelephoneNumber = 0x3A21,
        PidTagParentEntryId = 0x0E09,
        PidTagParentFolderId = 0x6749,
        PidTagParentKey = 0x0025,
        PidTagParentSourceKey = 0x65E1,
        PidTagPersonalHomePage = 0x3A50,
        PidTagPolicyTag = 0x3019,
        PidTagPostalAddress = 0x3A15,
        PidTagPostalCode = 0x3A2A,
        PidTagPostOfficeBox = 0x3A2B,
        PidTagPredecessorChangeList = 0x65E3,
        PidTagPrimaryFaxNumber = 0x3A23,
        PidTagPrimarySendAccount = 0x0E28,
        PidTagPrimaryTelephoneNumber = 0x3A1A,
        PidTagPriority = 0x0026,
        PidTagProcessed = 0x7D01,
        PidTagProfession = 0x3A46,
        PidTagProhibitReceiveQuota = 0x666A,
        PidTagProhibitSendQuota = 0x666E,
        PidTagPurportedSenderDomain = 0x4083,
        PidTagRadioTelephoneNumber = 0x3A1D,
        PidTagRead = 0x0E69,
        PidTagReadReceiptAddressType = 0x4029,
        PidTagReadReceiptEmailAddress = 0x402A,
        PidTagReadReceiptEntryId = 0x0046,
        PidTagReadReceiptName = 0x402B,
        PidTagReadReceiptRequested = 0x0029,
        PidTagReadReceiptSearchKey = 0x0053,
        PidTagReadReceiptSmtpAddress = 0x5D05,
        PidTagReceiptTime = 0x002A,
        PidTagReceivedByAddressType = 0x0075,
        PidTagReceivedByEmailAddress = 0x0076,
        PidTagReceivedByEntryId = 0x003F,
        PidTagReceivedByName = 0x0040,
        PidTagReceivedBySearchKey = 0x0051,
        PidTagReceivedBySmtpAddress = 0x0077,
        PidTagReceivedRepresentingEmailAddress = 0x0078,
        PidTagReceivedRepresentingEntryId = 0x0043,
        PidTagReceivedRepresentingName = 0x0044,
        PidTagReceivedRepresentingSearchKey = 0x0052,
        PidTagReceivedRepresentingSmtpAddress = 0x5D08,
        PidTagRecipientDisplayName = 0x5FF6,
        PidTagRecipientEntryId = 0x5FF7,
        PidTagRecipientFlags = 0x5FFD,
        PidTagRecipientOrder = 0x5FDF,
        PidTagRecipientProposed = 0x5FE1,
        PidTagRecipientProposedEndTime = 0x5FE4,
        PidTagRecipientProposedStartTime = 0x5FE3,
        PidTagRecipientReassignmentProhibited = 0x002B,
        PidTagRecipientTrackStatus = 0x5FFF,
        PidTagRecipientTrackStatusTime = 0x5FFB,
        PidTagRecipientType = 0x0C15,
        PidTagRecordKey = 0x0FF9,
        PidTagReferredByName = 0x3A47,
        PidTagRemindersOnlineEntryId = 0x36D5,
        PidTagRemoteMessageTransferAgent = 0x0C21,
        PidTagRenderingPosition = 0x370B,
        PidTagReplyRecipientEntries = 0x004F,
        PidTagReplyRecipientNames = 0x0050,
        PidTagReplyRequested = 0x0C17,
        PidTagReplyTemplateId = 0x65C2,
        PidTagReplyTime = 0x0030,
        PidTagReportDisposition = 0x0080,
        PidTagReportDispositionMode = 0x0081,
        PidTagReportEntryId = 0x0045,
        PidTagReportingMessageTransferAgent = 0x6820,
        PidTagReportName = 0x003A,
        PidTagReportSearchKey = 0x0054,
        PidTagReportTag = 0x1001,
        PidTagReportTime = 0x0032,
        PidTagResolveMethod = 0x3FE7,
        PidTagResponseRequested = 0x0063,
        PidTagResponsibility = 0x0E0F,
        PidTagRetentionDate = 0x301C,
        PidTagRetentionFlags = 0x301D,
        PidTagRetentionPeriod = 0x301A,
        PidTagRights = 0x6639,
        PidTagRoamingDatatypes = 0x7C06,
        PidTagRoamingDictionary = 0x7C07,
        PidTagRoamingXmlStream = 0x7C08,
        PidTagRowid = 0x3000,
        PidTagRowType = 0x0FF5,
        PidTagRtfCompressed = 0x1009,
        PidTagRtfInSync = 0x0E1F,
        PidTagRuleActionNumber = 0x6650,
        PidTagRuleActions = 0x6680,
        PidTagRuleActionType = 0x6649,
        PidTagRuleCondition = 0x6679,
        PidTagRuleError = 0x6648,
        PidTagRuleFolderEntryId = 0x6651,
        PidTagRuleId = 0x6674,
        PidTagRuleIds = 0x6675,
        PidTagRuleLevel = 0x6683,
        PidTagRuleMessageLevel = 0x65ED,
        PidTagRuleMessageName = 0x65EC,
        PidTagRuleMessageProvider = 0x65EB,
        PidTagRuleMessageProviderData = 0x65EE,
        PidTagRuleMessageSequence = 0x65F3,
        PidTagRuleMessageState = 0x65E9,
        PidTagRuleMessageUserFlags = 0x65EA,
        PidTagRuleName = 0x6682,
        PidTagRuleProvider = 0x6681,
        PidTagRuleProviderData = 0x6684,
        PidTagRuleSequence = 0x6676,
        PidTagRuleState = 0x6677,
        PidTagRuleUserFlags = 0x6678,
        PidTagRwRulesStream = 0x6802,
        PidTagScheduleInfoAppointmentTombstone = 0x686A,
        PidTagScheduleInfoAutoAcceptAppointments = 0x686D,
        PidTagScheduleInfoDelegateEntryIds = 0x6845,
        PidTagScheduleInfoDelegateNames = 0x6844,
        PidTagScheduleInfoDelegateNamesW = 0x684A,
        PidTagScheduleInfoDelegatorWantsCopy = 0x6842,
        PidTagScheduleInfoDelegatorWantsInfo = 0x684B,
        PidTagScheduleInfoDisallowOverlappingAppts = 0x686F,
        PidTagScheduleInfoDisallowRecurringAppts = 0x686E,
        PidTagScheduleInfoDontMailDelegates = 0x6843,
        PidTagScheduleInfoFreeBusy = 0x686C,
        PidTagScheduleInfoFreeBusyAway = 0x6856,
        PidTagScheduleInfoFreeBusyBusy = 0x6854,
        PidTagScheduleInfoFreeBusyMerged = 0x6850,
        PidTagScheduleInfoFreeBusyTentative = 0x6852,
        PidTagScheduleInfoMonthsAway = 0x6855,
        PidTagScheduleInfoMonthsBusy = 0x6853,
        PidTagScheduleInfoMonthsMerged = 0x684F,
        PidTagScheduleInfoMonthsTentative = 0x6851,
        PidTagScheduleInfoResourceType = 0x6841,
        PidTagSchedulePlusFreeBusyEntryId = 0x6622,
        PidTagScriptData = 0x0004,
        PidTagSearchFolderDefinition = 0x6845,
        PidTagSearchFolderEfpFlags = 0x6848,
        PidTagSearchFolderExpiration = 0x683A,
        PidTagSearchFolderId = 0x6842,
        PidTagSearchFolderLastUsed = 0x6834,
        PidTagSearchFolderRecreateInfo = 0x6844,
        PidTagSearchFolderStorageType = 0x6846,
        PidTagSearchFolderTag = 0x6847,
        PidTagSearchFolderTemplateId = 0x6841,
        PidTagSearchKey = 0x300B,
        PidTagSecurityDescriptorAsXml = 0x0E6A,
        PidTagSelectable = 0x3609,
        PidTagSenderAddressType = 0x0C1E,
        PidTagSenderEmailAddress = 0x0C1F,
        PidTagSenderEntryId = 0x0C19,
        PidTagSenderIdStatus = 0x4079,
        PidTagSenderName = 0x0C1A,
        PidTagSenderSearchKey = 0x0C1D,
        PidTagSenderSmtpAddress = 0x5D01,
        PidTagSenderTelephoneNumber = 0x6802,
        PidTagSendInternetEncoding = 0x3A71,
        PidTagSendRichInfo = 0x3A40,
        PidTagSensitivity = 0x0036,
        PidTagSentMailSvrEID = 0x6740,
        PidTagSentRepresentingAddressType = 0x0064,
        PidTagSentRepresentingEmailAddress = 0x0065,
        PidTagSentRepresentingEntryId = 0x0041,
        PidTagSentRepresentingFlags = 0x401A,
        PidTagSentRepresentingName = 0x0042,
        PidTagSentRepresentingSearchKey = 0x003B,
        PidTagSentRepresentingSmtpAddress = 0x5D02,
        PidTagSerializedReplidGuidMap = 0x6638,
        PidTagSmtpAddress = 0x39FE,
        PidTagSortLocaleId = 0x6705,
        PidTagSourceKey = 0x65E0,
        PidTagSpokenName = 0x8CC2,
        PidTagSpouseName = 0x3A48,
        PidTagStartDate = 0x0060,
        PidTagStartDateEtc = 0x301B,
        PidTagStateOrProvince = 0x3A28,
        PidTagStoreEntryId = 0x0FFB,
        PidTagStoreState = 0x340E,
        PidTagStoreSupportMask = 0x340D,
        PidTagStreetAddress = 0x3A29,
        PidTagSubfolders = 0x360A,
        PidTagSubject = 0x0037,
        PidTagSubjectPrefix = 0x003D,
        PidTagSupplementaryInfo = 0x0C1B,
        PidTagSurname = 0x3A11,
        PidTagSwappedToDoData = 0x0E2D,
        PidTagSwappedToDoStore = 0x0E2C,
        PidTagTargetEntryId = 0x3010,
        PidTagTelecommunicationsDeviceForDeafTelephoneNumber = 0x3A4B,
        PidTagTelexNumber = 0x3A2C,
        PidTagTemplateData = 0x0001,
        PidTagTemplateid = 0x3902,
        PidTagTextAttachmentCharset = 0x371B,
        PidTagThumbnailPhoto = 0x8C9E,
        PidTagTitle = 0x3A17,
        PidTagTnefCorrelationKey = 0x007F,
        PidTagToDoItemFlags = 0x0E2B,
        PidTagTransmittableDisplayName = 0x3A20,
        PidTagTransportMessageHeaders = 0x007D,
        PidTagTrustSender = 0x0E79,
        PidTagUserCertificate = 0x3A22,
        PidTagUserEntryId = 0x6619,
        PidTagUserX509Certificate = 0x3A70,
        PidTagViewDescriptorBinary = 0x7001,
        PidTagViewDescriptorName = 0x7006,
        PidTagViewDescriptorStrings = 0x7002,
        PidTagViewDescriptorVersion = 0x7007,
        PidTagVoiceMessageAttachmentOrder = 0x6805,
        PidTagVoiceMessageDuration = 0x6801,
        PidTagVoiceMessageSenderName = 0x3A41,
        PidTagWlinkAddressBookEID = 0x6854,
        PidTagWlinkAddressBookStoreEID = 0x6891,
        PidTagWlinkCalendarColor = 0x6853,
        PidTagWlinkClientID = 0x6890,
        PidTagWlinkEntryId = 0x684C,
        PidTagWlinkFlags = 0x684A,
        PidTagWlinkFolderType = 0x684F,
        PidTagWlinkGroupClsid = 0x6850,
        PidTagWlinkGroupHeaderID = 0x6842,
        PidTagWlinkGroupName = 0x6851,
        PidTagWlinkOrdinal = 0x684B,
        PidTagWlinkRecordKey = 0x684D,
        PidTagWlinkROGroupType = 0x6892,
        PidTagWlinkSaveStamp = 0x6847,
        PidTagWlinkSection = 0x6852,
        PidTagWlinkStoreEntryId = 0x684E,
        PidTagWlinkType = 0x6849,
    }
}
