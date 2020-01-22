namespace BookStore.BusinessLogic.Common.Constants
{

    public partial class Constants
    {
        public class ErrorConstants
        {
            public const string RefreshTokenIsNotValidError = "Refresh token is not valid";
            public const string UserNotFoundError = "User not found";
            public const string WrongUsernameOrPassword = "Wrong username or password";
            public const string UserIdIsEmptyError = "User id is empty";
            public const string UserEmailIsEmptyError = "User email Is empty";
            public const string UserNameIsEmptyError = "User name Is empty";
            public const string UserModelItemIsEmptyError = "UserModelItem Is empty";
            public const string UsersFilterModelIsEmptyError = "UsersFilterModel Is empty";
            public const string UserWithThatEmailAlreadyExistsError = "A user with that email already exists";
            public const string UserNotCreatedError = "User not created";
            public const string EmailConfirmationTokenNotGeneratedError = "Email confirmation token not generated";
            public const string PasswordResetTokenNotGeneratedError = "Password reset token not generated";
            public const string TokenOrUserIdIsEmptyError = "Token or user id is empty";
            public const string EmailNotConfirmedError = "Email not confirmed";
            public const string PasswordNotChangedError = "Password not changed";

            public const string AuthorIdIsZeroError = "Author id is zero";
            public const string AuthorNotFoundError = "Author not found";
            public const string AuthorModelItemIsEmptyError = "AuthorModelItem Is empty";
            public const string AuthorNameIsMissingError = "Author name is missing";

            public const string DataNotUpdatedError = "Data not updated";
            public const string DataNotRemovedError = "Data not removed";

            public const string BaseFilterModelIsEmptyError = "BaseFilterModel is empty";
            public const string AuthorNotCreatedError = "Author not created";

            public const string OrderIdIsZeroError = "Order id is zero";
            public const string OrderNotFoundError = "Order not found";
            public const string CartModelIsEmptyError = "CartModel is empty";
            public const string OrdersFilterModelIsEmptyError = "OrdersFilterModel is empty";

            public const string PrintingEditionIdIsZeroError = "PrintingEdition id is zero";
            public const string PrintingEditionNotFoundError = "PrintingEdition not found";
            public const string PrintingEditionModelItemIsEmptyError = "PrintingEditionModelItem is empty";
            public const string NoTitle = "No title";
            public const string ProductTypeNotAssigned = "Product type not assigned";
            public const string NoCurrencyAssigned = "No currency assigned";
            public const string PrintingEditionNotCreatedError = "PrintingEdition not created";            
            //...
        }
    }

}