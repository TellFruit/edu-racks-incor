import i18n from "i18next";
import { initReactI18next } from "react-i18next";

import enTranslation from "../locales/en.json";
import ukTranslation from "../locales/uk.json";

const resources = {
  en: {
    translation: enTranslation
  },
  uk: {
    translation: ukTranslation
  }
};

i18n
  .use(initReactI18next)
  .init({
    resources,
    lng: "en",
    fallbackLng: "en",
    interpolation: {
      escapeValue: false
    }
  });

export default i18n;
