const PROXY_CONFIG = [
  {
    context: [
      "/getToken",
      "/getContacts",
      "/getContactsWithFilter",
      "/createContact",
      "/updateContact",
      "/deleteContact",
      //"/weatherforecast",
      //"/api/values",
    ],
    target: "https://localhost:7248",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
