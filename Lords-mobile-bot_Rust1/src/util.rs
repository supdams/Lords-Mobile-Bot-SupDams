use dns_lookup::lookup_host;

pub fn get_ip(main_ip: String, proxy: bool) -> String {
    let start = if proxy { "proxy" } else { "login" };
    let url = format!("lm-{}-{}.igg.com", start, main_ip.replace('.', "-"));
    if let Ok(ips) = lookup_host(&url) {
        if let Some(ip) = ips.get(0) {
            //println!("{} -> {}", url, ip);
            return ip.to_string();
        }
    }
    main_ip
}
pub fn get_color_code(name: &str) -> &'static str {
    // Limited ANSI color converter.
    if name == "red" {
        "1"
    } else if name == "green" {
        "2"
    } else if name == "blue" {
        "4"
    } else if name == "white" {
        "7"
    } else {
        "0" // Black.
    }
}

pub fn get_color(value: &str, bold: bool, color: &str, background: &str) -> String {
    // Get string with console color information.
    let mut result = String::from("\u{1b}[");
    // [1;] means bold.
    if bold {
        result.push_str("1;");
    }
    // Handle foreground.
    if !color.is_empty() {
        result.push_str("38;5;"); // Codes for ANSI foreground.
        result.push_str(get_color_code(color));
        result.push(';');
    }
    // Handle background.
    if !background.is_empty() {
        result.push_str("48;5;"); // Codes for ANSI background.
        result.push_str(get_color_code(background));
        result.push(';');
    }
    result.push_str("7m"); // End token.
    result.push_str(value);
    result.push_str("\u{1b}[0m");
    result
}