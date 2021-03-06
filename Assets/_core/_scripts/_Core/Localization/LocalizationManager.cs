using System;
using Antura.Database;
using Antura.Profile;

namespace Antura.Core
{
    /// <summary>
    /// Static class that helps in localizing strings.
    /// </summary>
    public class LocalizationManager
    {

        private static PlayerGender CurrentPlayerGender
        {
            get {
                if (AppManager.I.Player == null) {
                    return AppManager.I.PlayerProfileManager.TemporaryPlayerGender;
                }
                return AppManager.I.Player.Gender;
            }
        }

        public static string GetNative(LocalizationDataId id)
        {
            return GetLocalizationData(id).GetNativeText();
        }

        public static string GetTranslation(LocalizationDataId id)
        {
            return GetLocalizationData(id).GetLocalizedText(CurrentPlayerGender);
        }

        public static string GetTranslation(string id)
        {
            return GetLocalizationData(id).GetLocalizedText(CurrentPlayerGender);
        }

        public static string GetLocalizedAudioFileName(string id)
        {
            return GetLocalizationData(id).GetLocalizedAudioFileName(CurrentPlayerGender);
        }

        public static string GetLocalizedAudioFileName(string id, PlayerGender forcedGender)
        {
            return GetLocalizationData(id).GetLocalizedAudioFileName(forcedGender);
        }

        public static LocalizationData GetLocalizationData(LocalizationDataId id)
        {
            return AppManager.I.DB.GetLocalizationDataById(id.ToString());
        }

        public static LocalizationData GetLocalizationData(string id)
        {
            return AppManager.I.DB.GetLocalizationDataById(id);
        }

        public static LocalizationData GetWordCategoryData(WordDataCategory cat)
        {
            LocalizationDataId loc = (LocalizationDataId)Enum.Parse(typeof(LocalizationDataId), $"UI_WordCat_{cat}");
            return GetLocalizationData(loc);
        }

        public static LocalizationData GetPhraseCategoryData(PhraseDataCategory cat)
        {
            LocalizationDataId loc = (LocalizationDataId)Enum.Parse(typeof(LocalizationDataId), $"UI_Phrases_{cat}");
            return GetLocalizationData(loc);
        }
    }
}