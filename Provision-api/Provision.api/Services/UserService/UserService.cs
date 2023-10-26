namespace Provision.api.Services.UserService;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserService(IMapper mapper, DataContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    private async Task<ServiceResponse<T>> HandleException<T>(Exception ex)
    {
        return new ServiceResponse<T>
        {
            Data = default,
            Success = false,
            Message = $"An error occurred: {ex.Message}"

        };
    }

    private string HashPassword(string plainPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public async Task<ServiceResponse<List<GetUserResponseDto>>> GetAllUsers()
    {
        try
        {
            var dbLoginQrCodes = await _context.Users.ToListAsync();
            var mappedQrCodes = _mapper.Map<List<GetUserResponseDto>>(dbLoginQrCodes);

            return new ServiceResponse<List<GetUserResponseDto>>
            {
                Data = mappedQrCodes,
                Success = true,
                Message = "Users retrieved successfully."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<List<GetUserResponseDto>>(ex);
        }
    }

    public async Task<ServiceResponse<GetUserResponseDto>> GetUserById(int id)
    {
        try
        {
            var dbQrCode = await _context.Users.FirstOrDefaultAsync(qr => qr.Id == id);
            if (dbQrCode is null)
            {
                return new ServiceResponse<GetUserResponseDto>
                {
                    Data = default,
                    Success = false,
                    Message = "User not found"
                };
            }
            var mappedQrCode = _mapper.Map<GetUserResponseDto>(dbQrCode);

            return new ServiceResponse<GetUserResponseDto>
            {
                Data = mappedQrCode,
                Success = true,
                Message = "User retrieved by ID successfully."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<GetUserResponseDto>(ex);
        }
    }

    public async Task<ServiceResponse<GetUserResponseDto>> GetUserByString(string targetString)
    {
        try
        {
            var dbQrCode = await _context.Users.FirstOrDefaultAsync(qr => qr.UserName == targetString);
            if (dbQrCode is null)
            {
                return new ServiceResponse<GetUserResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "User not found"
                };
            }

            var mappedQrCode = _mapper.Map<GetUserResponseDto>(dbQrCode);

            return new ServiceResponse<GetUserResponseDto>
            {
                Data = mappedQrCode,
                Success = true,
                Message = "User retrieved by string successfully."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<GetUserResponseDto>(ex);
        }
    }

    public async Task<ServiceResponse<List<GetUserResponseDto>>> AddUser(AddUserRequestDto newLoginQrCode)
    {
        try
        {
            string hashedPassword = HashPassword(newLoginQrCode.Password);

            var newQrCode = _mapper.Map<User>(newLoginQrCode);
            newQrCode.Password = hashedPassword;

            await _context.Users.AddAsync(newQrCode);
            await _context.SaveChangesAsync();

            var updatedQrCodes = await _context.Users.ToListAsync();
            var updatedQrCodesResponse = _mapper.Map<List<GetUserResponseDto>>(updatedQrCodes);

            return new ServiceResponse<List<GetUserResponseDto>>
            {
                Data = updatedQrCodesResponse,
                Success = true,
                Message = "User added successfully."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<List<GetUserResponseDto>>(ex);
        }
    }

    public async Task<ServiceResponse<List<GetUserResponseDto>>> DeleteUserById(int id)
    {
        try
        {
            var loginQrCode = await _context.Users.FirstOrDefaultAsync(qr => qr.Id == id);
            if (loginQrCode is null)
            {
                throw new Exception($"User with ID '{id}' not found");
            }

            _context.Users.Remove(loginQrCode);
            await _context.SaveChangesAsync();

            return new ServiceResponse<List<GetUserResponseDto>>
            {
                Success = true,
                Message = "User deleted successfully."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<List<GetUserResponseDto>>(ex);
        }
    }

    public async Task<ServiceResponse<GetUserResponseDto>> Login(string targetQrString, string password)
    {
        try
        {
            var loginQrCode = await _context.Users.FirstOrDefaultAsync(qr => qr.UserName == targetQrString);
            if (loginQrCode is null)
            {
                throw new Exception("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, loginQrCode.Password))
            {
                throw new Exception("Password for user is not correct.");

            }
            return new ServiceResponse<GetUserResponseDto>
            {
                Success = true,
                Message = "Password is correct, login authorized."
            };
        }
        catch (Exception ex)
        {
            return await HandleException<GetUserResponseDto>(ex);
        }
    }
}

