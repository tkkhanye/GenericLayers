import { DealerWebPage } from './app.po';

describe('dealer-web App', () => {
  let page: DealerWebPage;

  beforeEach(() => {
    page = new DealerWebPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
