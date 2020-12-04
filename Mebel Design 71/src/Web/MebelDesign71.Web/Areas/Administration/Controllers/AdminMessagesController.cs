﻿namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AdminMessagesController : AdministrationController
    {
        private readonly IMessagesService messagesService;

        public AdminMessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public IActionResult Index()
        {
            var allMessages = this.messagesService.GetAllMessages();
            var deletedMessage = this.messagesService.GetIsDeletedMessages();
            this.ViewData["allMessages"] = allMessages;

            return this.View();
        }

        public IActionResult Write(string id, string email, string about)
        {
            this.ViewData["toMessageId"] = id;
            this.ViewData["email"] = email;
            this.ViewData["about"] = about;

            return this.View();
        }

        [HttpPost]
        public IActionResult Write(SendMessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.View();
        }

        public IActionResult Read(string id)
        {
            var currentMessage = this.messagesService.GetMessageById(id);

            return this.View(currentMessage);
        }

        public IActionResult Send()
        {
            var allSendMessages = this.messagesService.GetAllSendMessages();
            this.ViewData["allMessages"] = allSendMessages;

            return this.View();
        }

        public IActionResult Trash()
        {
            var allDeletedMessages = this.messagesService.GetIsDeletedMessages();
            this.ViewData["allDeletedMessages"] = allDeletedMessages;

            return this.View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.messagesService.Delete(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Undelete(string id)
        {
            await this.messagesService.Restore(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> HardDelete(string id)
        {
            await this.messagesService.HardDelete(id);

            return this.RedirectToAction("Index");
        }
    }
}