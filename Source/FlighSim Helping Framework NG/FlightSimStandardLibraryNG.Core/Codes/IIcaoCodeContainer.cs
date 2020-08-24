﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

namespace FlightSimStandardLibraryNG.Core.Codes
{
    /// <summary>
    ///     Interface of a class, that contains <see cref="IcaoCode" /> for representing airport
    ///     ICAO code.
    /// </summary>
    public interface IIcaoCodeContainer
    {
        /// <summary>
        ///     Airport ICAO code.
        /// </summary>
        IcaoCode AirportIcaoCode { get; }
    }
}