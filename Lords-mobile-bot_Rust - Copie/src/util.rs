use dns_lookup::lookup_host;

pub fn get_ip(main_ip: String, proxy: bool) -> String {
    let start = if proxy { "proxy" } else { "login" };
    let url = format!("lm-{}-{}.igg.com", start, main_ip.replace('.', "-"));
    if let Ok(ips) = lookup_host(&url) {
        if let Some(ip) = ips.get(0) {
            println!("{} -> {}", url, ip);
            return ip.to_string();
        }
    }
    main_ip
}
