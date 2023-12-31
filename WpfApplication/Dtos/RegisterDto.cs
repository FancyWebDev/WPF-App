﻿using Newtonsoft.Json;

namespace WpfApplication.Dtos;

public record RegisterDto
{
    [JsonProperty("login")]
    public string Login { get; set; }
    [JsonProperty("password_hash")]
    public string PasswordHash { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
}