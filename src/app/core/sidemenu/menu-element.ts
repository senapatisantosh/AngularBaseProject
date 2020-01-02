export const menus = [
    {
        'name': 'Dashboard',
        'icon': 'dashboard',
        'link': false,
        'open': false,
        'chip': { 'value': 1, 'color': 'accent' },
        'sub': [
            {
                'name': 'Dashboard',
                'link': '/auth/dashboard',
                'icon': 'dashboard',
                'chip': false,
                'open': true,
            }
        ]
    }
];
